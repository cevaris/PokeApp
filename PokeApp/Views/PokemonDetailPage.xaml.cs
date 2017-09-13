using PokeApp.Utils;
using Xamarin.Forms;

namespace PokeApp
{
    public partial class PokemonDetailPage : ContentPage
    {
        private ILogger logger = new ConsoleLogger(nameof(PokemonDetailPage));

        public PokemonDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                DetailSection.Orientation = StackOrientation.Horizontal;
                logger.Info("setting orientation to Horizontal");
            }
            else
            {
                DetailSection.Orientation = StackOrientation.Vertical;
                logger.Info("setting orientation to Vertical");
            }
        }
    }
}
