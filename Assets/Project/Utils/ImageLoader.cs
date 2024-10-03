using UnityEngine;
using Cysharp.Threading.Tasks;

namespace TestProject
{
    public class ImageLoader
    {
        public Sprite FirstSprite {  get; private set; }
        public Sprite SecondSprite { get; private set; }
        public Sprite ThirdSprite { get; private set; }
        public Sprite FortedSprite { get; private set; }
        public Sprite FiftedSprite { get; private set; }


        public async UniTask LoadSprites()
        {
            var uwr = WWW.LoadFromCacheOrDownload(AppConstants.BundleLink, 2);
            await uwr;
            if (!string.IsNullOrEmpty(uwr.error))
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                var assetBundle = uwr.assetBundle;
                string imageName = "Test6";
                string imageName1 = "TestImage1";
                string imageName2 = "TestImage2";
                string imageName3 = "TestImage3";
                string imageName4 = "TestImage4";

                var spriteRequest = await assetBundle.LoadAssetAsync(imageName, typeof(Sprite));
                FirstSprite = spriteRequest as Sprite;

                var spriteRequest1 = await assetBundle.LoadAssetAsync(imageName1, typeof(Sprite));
                SecondSprite = spriteRequest1 as Sprite;

                var spriteRequest2 = await assetBundle.LoadAssetAsync(imageName2, typeof(Sprite));
                ThirdSprite = spriteRequest2 as Sprite;

                var spriteRequest3 = await assetBundle.LoadAssetAsync(imageName3, typeof(Sprite));
                FortedSprite = spriteRequest3 as Sprite;

                var spriteRequest4 = await assetBundle.LoadAssetAsync(imageName4, typeof(Sprite));
                FiftedSprite = spriteRequest4 as Sprite;
            }
        }
    }
}
