using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.DataLayerSql
{
    public class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    }

    public static class StoreProcedure
    {
        // Users
        public static string GetUserByUsernamePassword = "sp_GetUserByUsernamePassword";

        /*// Banner
        public static string GetBannerById = "sp_GetBannerDetails";
        public static string InsertBanner = "sp_InsertBanner";
        public static string UpdateBanner = "sp_UpdateBanner";
        public static string GetAllBanners = "sp_GetBanner";
        public static string DeleteBanner = "sp_DeleteBanner";

        // About Us
        public static string GetAboutDetails = "sp_GetAboutUDetails";
        public static string UpdateAbout = "sp_UpdateAboutU";


        // Our Clients Banner
        public static string GetClientBannersDetails = "sp_GetClientBannersDetails";
        public static string UpdateClientsBanner = "sp_UpdateClientsBanner";


        // Clients
        public static string GetAllClients = "sp_GetOurClient";
        public static string GetClientById = "sp_GetOurClientDetails";
        public static string InsertClient = "sp_InsertOurClient";
        public static string UpdateClient = "sp_UpdateOurClient";
        public static string DeleteClient = "sp_DeleteOurClient";

        // Company Setting
        public static string GetCompanySetting = "sp_GetCompanySettingDetails";
        public static string UpdateCompanySettings = "sp_UpdateCompanySetting";

        // Machines
        public static string GetAllMachines = "sp_GetOurMachine";
        public static string GetMachineById = "sp_GetOurMachineDetails";
        public static string InsertMachine = "sp_InsertOurMachine";
        public static string UpdateMachine = "sp_UpdateOurMachine";
        public static string DeleteMachine = "sp_DeleteOurMachine";

        // Services
        public static string GetAllServices = "sp_GetOurService";
        public static string GetServicesById = "sp_GetOurServiceDetails";
        public static string InsertServices = "sp_InsertOurService";
        public static string UpdateServices = "sp_UpdateOurService";
        public static string DeleteService = "sp_DeleteOurService";

        //Projects
        public static string GetAllProjects = "sp_GetProject";
        public static string GetProjectsById = "sp_GetProjectDetails";
        public static string InsertProjects = "sp_InsertProject";
        public static string UpdateProjects = "sp_UpdateProject";
        public static string DeleteProject = "sp_DeleteProject";

        // Project Category
        public static string GetAllProjectCategory = "sp_GetProjectCategory";
        public static string GetProjectCategoryById = "sp_GetProjectCategoryDetails";
        public static string InsertProjectCategory = "sp_InsertProjectCategory";
        public static string UpdateProjectCategory = "sp_UpdateProjectCategory";
        public static string DeleteProjectCategory = "sp_DeleteProjectCategory";

        // Project SubCategory
        public static string GetAllProjectSubCategory = "sp_GetProjectSubCategory";
        public static string GetProjectSubCategoryById = "sp_GetProjectSubCategoryDetails";
        public static string InsertProjectSubCategory = "sp_InsertProjectSubCategory";
        public static string UpdateProjectSubCategory = "sp_UpdateProjectSubCategory";
        public static string DeleteProjectSubCategory = "sp_DeleteProjectSubCategory";
        public static string GetSubCategoryByCategoryId = "sp_GetSubCategoryByCategoryId";

        // Project Gallery
        public static string GetAllProjectGallery = "sp_GetProjectGallery";
        public static string GetProjectGalleryById = "sp_GetProjectGalleryDetails";
        public static string InsertProjectGallery = "sp_InsertProjectGallery";
        public static string UpdateProjectGallery = "sp_UpdateProjectGallery";
        public static string DeleteProjectGallery = "sp_DeleteProjectGallery";
        public static string GetAllProjectsByCategoryId = "sp_GetProjectsByCategoryId";
        public static string GetAllProjectsBySubCategoryId = "sp_GetProjectsBySubCategoryId";
        public static string GetAllProjectGalleriesByProjectId = "sp_GetProjectGalleriesByProjectId";
        // Feedback
        public static string GetAllFeedback = "sp_GetFeedback";
        public static string GetFeedbackById = "sp_GetFeedbackDetails";
        public static string InsertFeedback = "sp_InsertFeedback";
        public static string UpdateFeedback = "sp_UpdateFeedback";
        public static string DeleteFeedback = "sp_DeleteFeedback";*/
    }
}