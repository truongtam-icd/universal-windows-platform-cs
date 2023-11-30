using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using universal_windows_platform_c_.ViewModels;

namespace universal_windows_platform_c_.Tests.MSTest
{
    // TODO: Add appropriate tests
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        // TODO: Add tests for functionality you add to MainViewModel.
        [TestMethod]
        public void TestMainViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new MainViewModel();
            Assert.IsNotNull(vm);
        }

        // TODO: Add tests for functionality you add to SettingsViewModel.
        [TestMethod]
        public void TestSettingsViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new SettingsViewModel();
            Assert.IsNotNull(vm);
        }

        // TODO: Add tests for functionality you add to UserDetailViewModel.
        [TestMethod]
        public void TestUserDetailViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new UserDetailViewModel();
            Assert.IsNotNull(vm);
        }

        // TODO: Add tests for functionality you add to UserListViewModel.
        [TestMethod]
        public void TestUserListViewModelCreation()
        {
            // This test is trivial. Add your own tests for the logic you add to the ViewModel.
            var vm = new UserListViewModel();
            Assert.IsNotNull(vm);
        }
    }
}
