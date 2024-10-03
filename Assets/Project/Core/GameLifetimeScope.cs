using VContainer;
using VContainer.Unity;

namespace TestProject
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<EventBase>(Lifetime.Singleton).AsSelf();
            builder.Register<ImageLoader>(Lifetime.Singleton).AsSelf();

            builder.Register<UIModel>(Lifetime.Singleton).AsSelf();
            builder.Register<UIPresenter>(Lifetime.Singleton).AsSelf();

            builder.Register<SceneLoader>(Lifetime.Singleton).AsSelf();
            builder.RegisterEntryPoint<AppStart>();
        }
    }
}
