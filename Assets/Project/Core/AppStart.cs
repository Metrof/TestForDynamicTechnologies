using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace TestProject
{
    public class AppStart : IAsyncStartable
    {
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private UIPresenter _uiPresenter;
        [Inject] private ImageLoader _imageLoader;
        public async Task StartAsync(CancellationToken cancellation = default)
        {
            await _imageLoader.LoadSprites();
            _uiPresenter.Init();
            await _sceneLoader.OpenScene(AppConstants.MainSceneID, LoadSceneMode.Single);
        }
    }
}

