using HMUI;
using BSNotes.UI;

namespace BSNotes.FlowCoordinators
{
    internal class BSNotesFlowCoordinator : FlowCoordinator
    {
        private BSNotesSettingsViewController _bsNotesSettingsViewController = null!;

        public void Construct(BSNotesSettingsViewController bsNotesSettingsViewController)
        {
            _bsNotesSettingsViewController = bsNotesSettingsViewController;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            // ProvideInitialViewControllers(_bsNotesSettingsViewController);
            /*try
            {
                if (firstActivation)
                {
                    SetTitle("Name of the Menu Button :)");
                    showBackButton = true;
                    // ProvideInitialViewControllers( _bsNotesViewController);
                }
            }
            catch (Exception ex)
            {
                _siraLog.Error(ex);
            }*/
        }

        /*protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlowCoordinator.DismissFlowCoordinator(this);
        }*/
    }
}