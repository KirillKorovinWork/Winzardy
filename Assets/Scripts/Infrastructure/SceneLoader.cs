using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public async void Load(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);
    }

    public async Task LoadAsync(string sceneName) =>
        await SceneManager.LoadSceneAsync(sceneName);
}
