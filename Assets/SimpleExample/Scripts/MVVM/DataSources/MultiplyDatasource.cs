using UniRx;
using UnityEngine;

namespace SimpleExample.Scripts.MVVM.DataSources
{
    [CreateAssetMenu(fileName = "MultiplyDatasource", menuName = "SimpleExample/DataSources/Multiply")]
    public class MultiplyDatasource : ScriptableObject
    {
        public readonly ReactiveProperty<int> Current = new ReactiveProperty<int>(0);

        public void Set(int value) => Current.Value = value;
    }
}
