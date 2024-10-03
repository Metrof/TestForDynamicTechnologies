using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using VContainer;

namespace TestProject
{
    public class SceneLoader
    {
        [Inject] private EventBase _eventBase;
        public async UniTask OpenScene(int sceneId, LoadSceneMode mode)
        {
            await SceneManager.LoadSceneAsync(sceneId, mode).ToUniTask();
            var scene = SceneManager.GetActiveScene();
            var mainSceneManager = scene.GetRoot<MainSceneManager>();
            mainSceneManager.Initialization(_eventBase);
        }
    }
}
