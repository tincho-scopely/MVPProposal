using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVVMFramework.Properties;
using MVVMFramework.Repositories;
using MVVMFramework.Wiring;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using UniRx;
using static MVVMFramework.Tests.Mothers.ViewModelMother;

namespace MVVMFramework.Tests
{
    [TestFixture]
    public class ViewModelWiringShould
    {
        ViewModelWiring viewModelWiring;
        ViewModel viewModel;
        List<WireField> wireResult;
        PropertyResolverRepository propertyResolverRepository;
        PropertyResolver somePropertyResolver;

        [SetUp]
        public void Setup()
        {
            propertyResolverRepository = Substitute.For<PropertyResolverRepository>();
            viewModel = SomeViewModel(propertyResolverRepository);
            somePropertyResolver = Substitute.For<PropertyResolver>();
            viewModelWiring = new ViewModelWiring(viewModel, propertyResolverRepository);

            somePropertyResolver.SubscribeProperty(Arg.Any<FieldInfo>(), Arg.Any<object>(),
                Arg.Any<Action<string, object>>()).Returns(Disposable.Empty);
        }
        
        [Test]
        public void WireViewModelProperty()
        {
            GivenAPropertyResolver();
            WhenWire();
            ThenWireResultIs(new List<WireField> { new WireField { Field = "SomeProperty", Subscription = Disposable.Empty}});
        }

        [Test]
        public void DoNotWireUnknownProperties()
        {
            GivenNoSupportedProperty();
            WhenWire();
            ThenWireResultIs(new List<WireField>());
        }

        [Test]
        public void SubscribeToPropertyChanges()
        {
            GivenAPropertyResolver();
            WhenWire();
            ThenSubscribePropertyIsCalled();
        }

        [Test]
        public void ReturnValueOfProperty()
        {
            GivenAPropertyResolver();
            WhenGetValueOf("SomeProperty");
            ThenGetValueIsCalled();
        }

        void GivenAPropertyResolver() =>
            propertyResolverRepository
                .GetBy(typeof(ReactiveProperty<int>))
                .Returns(somePropertyResolver);

        void GivenNoSupportedProperty() =>
            propertyResolverRepository
                .GetBy(typeof(ReactiveProperty<int>))
                .ReturnsNull();

        void WhenWire() => wireResult = viewModelWiring.Wire((s, o) => { });

        void WhenGetValueOf(string property) => viewModelWiring.GetValueOf(property);

        void ThenWireResultIs(List<WireField> expected) => 
            Assert.IsTrue(wireResult.SequenceEqual(expected));

        void ThenSubscribePropertyIsCalled() =>
            somePropertyResolver.Received(1)
                .SubscribeProperty(
                    Arg.Any<FieldInfo>(),
                    Arg.Any<ViewModel>(),
                    Arg.Any<Action<string, object>>()
                );

        void ThenGetValueIsCalled() => 
            somePropertyResolver.Received(1).GetValue(Arg.Any<FieldInfo>(), Arg.Is(viewModel));
    }
}