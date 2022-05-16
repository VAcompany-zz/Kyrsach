using Kyrsach.ViewModel;

namespace Kyrsach.Services
{
    public class VMLocator
    {
        public VMLocator()
        {
            VMService = new VMService();
        }
        public MainProgramViewModel MainVM => VMService.MainVM;
        public static VMService VMService { get; set; }
    }
}
