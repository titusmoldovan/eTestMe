using eTestMe.Core.Utility;
using eTestMe.Localization;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace eTestMe.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            InitializeIoc();

            RegisterAppStart(new AppStart());
        }

        void InitializeIoc()
        {
            CreatableTypes()
                            .EndingWith("Service")
                            .AsInterfaces()
                            .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IMvxTextProvider>(new ResxTextProvider(Strings.ResourceManager));
        }
    }
}