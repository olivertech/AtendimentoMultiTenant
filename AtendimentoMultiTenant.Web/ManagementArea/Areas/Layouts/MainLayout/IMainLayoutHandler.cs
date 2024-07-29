﻿namespace AtendimentoMultiTenant.Web.ManagementArea.Areas.Layouts.MainLayout
{
    public interface IMainLayoutHandler
    {
        void LoadMenu();
        Task<ResponseFactory<LoginResponse>> Logout(LoginRequest request);
        void GotoLoginPage();
        void GotoIndexPage();
    }
}