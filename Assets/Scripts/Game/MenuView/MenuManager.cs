


    public class MenuManager : IMenuManager
    {
        public Menu currentMenu;
        private Menu mainMenu;

        public void RegisterMainMenu(Menu mainMenu)
        {
            this.mainMenu = mainMenu;
            BackToMainMenu();
        }

        public void BackToMainMenu()
        {
            if (mainMenu == null)
                return;
            ShowMenu(mainMenu);
        }

        public void ShowMenu(Menu menu)
        {

            if (currentMenu != null)
                currentMenu.IsOpen = false;
            currentMenu = menu;
            currentMenu.IsOpen = true;
        }
    }
