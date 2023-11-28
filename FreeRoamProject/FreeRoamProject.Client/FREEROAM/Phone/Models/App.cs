using System.Threading.Tasks;

namespace FreeRoamProject.Client.FREEROAM.Phone.Models
{
    public abstract class App
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public IconLabels Icon { get; set; }
        public PhoneView CurrentView { get; set; }
        int SelectedItem;
        public bool OverrideBack { get; set; }
        public Phone Phone { get; set; }

        public App(string name, IconLabels icon, Phone phone, PhoneView view, bool overrideBack = true)
        {
            Name = name;
            Title = name;
            Icon = icon;
            Phone = phone;
            CurrentView = view;
            OverrideBack = overrideBack;
        }

        public abstract Task TickVisual();
        public abstract Task TickControls();

        public abstract void Initialize(Phone phone);

        public abstract void Kill();

    }
}
