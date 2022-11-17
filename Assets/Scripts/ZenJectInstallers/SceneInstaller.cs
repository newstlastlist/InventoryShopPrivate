using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public PlayerUImenuSystem PlayerUImenuSystem;
    public Transform PlayerTransform;
    public override void InstallBindings()
    {
        Container.BindInstance(PlayerUImenuSystem).AsSingle();
        Container.BindInstance(PlayerTransform).AsSingle();
    }
}
