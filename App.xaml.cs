using djaramilloS5.Repositories;

namespace djaramilloS5
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; private set; } = null!;

        public App(PersonRepository repo)
        {
            InitializeComponent();
            PersonRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
