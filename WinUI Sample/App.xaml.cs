using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Sample
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {

        private static IHost _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
        {

            services.AddSingleton<Model.DataBaseService>();
            services.AddSingleton<Model.ConfigurationManager>();


            services.AddSingleton<ViewModel.MainViewModel>();
            services.AddSingleton<ViewModel.HomeViewModel>();
            services.AddSingleton<ViewModel.LoginViewModel>();
            services.AddSingleton<ViewModel.TableViewModel>();
            services.AddSingleton<ViewModel.ItemDetailViewModel>();
            services.AddSingleton<ViewModel.ConfigurationViewModel>();


            services.AddSingleton<MainWindow>();
            services.AddSingleton<View.HomeView>();
            services.AddSingleton<View.LoginView>();
            services.AddSingleton<View.ViewManager>();
            services.AddSingleton<View.TablesView>();
            services.AddSingleton<View.ItemDetailView>();
            services.AddSingleton<View.ConfigurationView>();
        }).Build();

        public static T GetService<T>() where T : class => _host.Services.GetService(typeof(T)) as T;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            GetService<Model.DataBaseService>();
            GetService<Model.ConfigurationManager>().Load();

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = GetService<MainWindow>();
            m_window.Activate();
        }

        private Window m_window;
    }
}
