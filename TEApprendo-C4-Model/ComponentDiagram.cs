using Structurizr;

namespace C4_Model_Monolith
{
    public class ComponentDiagram
    {
        private readonly C4 c4;
        private readonly ContextDiagram contextDiagram;
        private readonly ContainerDiagram containerDiagram;

        public Component AuthenticationController { get; private set; } = null!;
        public Component SpecialistController { get; private set; } = null!;
        public Component GuardianController { get; private set; } = null!;
        public Component ChildController { get; private set; } = null!;
        public Component LevelController { get; private set; } = null!;
        public Component ObservationController { get; private set; } = null!;
        public Component DashboardController { get; private set; } = null!;

        public Component AuthenticationService { get; private set; } = null!;
        public Component SpecialistService { get; private set; } = null!;
        public Component GuardianService { get; private set; } = null!;
        public Component ChildService { get; private set; } = null!;
        public Component LevelService { get; private set; } = null!;
        public Component ObservationService { get; private set; } = null!;

        public Component AuthenticationRepository { get; private set; } = null!;
        public Component SpecialistRepository { get; private set; } = null!;
        public Component GuardianRepository { get; private set; } = null!;
        public Component ChildRepository { get; private set; } = null!;
        public Component LevelRepository { get; private set; } = null!;
        public Component ObservationRepository { get; private set; } = null!;

        public Component EmailSystemFacade { get; private set; } = null!;
        public Component SpecialistValidationFacade { get; private set; } = null!;

        public ComponentDiagram(C4 c4, ContextDiagram contextDiagram, ContainerDiagram containerDiagram)
        {
            this.c4 = c4;
            this.contextDiagram = contextDiagram;
            this.containerDiagram = containerDiagram;
        }

        public void Generate()
        {
            AddComponents();
            AddRelationships();
            ApplyStyles();
            CreateView();
        }

        private void AddComponents()
        {
            AuthenticationController = containerDiagram.RESTfulAPI.AddComponent("Authentication Controller", "RESTful API endpoints de autenticación.", "Spring Boot REST Controller");
            SpecialistController = containerDiagram.RESTfulAPI.AddComponent("Specialist Controller", "RESTful API endpoints de especialistas.", "Spring Boot REST Controller");
            GuardianController = containerDiagram.RESTfulAPI.AddComponent("Guardian Controller", "RESTful API endpoints de cuidadores.", "Spring Boot REST Controller");
            ChildController = containerDiagram.RESTfulAPI.AddComponent("Child Controller", "RESTful API endpoints de niños.", "Spring Boot REST Controller");
            ObservationController = containerDiagram.RESTfulAPI.AddComponent("Observation Controller", "RESTful API endpoints de observaciones.", "Spring Boot REST Controller");
            LevelController = containerDiagram.RESTfulAPI.AddComponent("Level Controller", "RESTful API endpoints de niveles.", "Spring Boot REST Controller");
            DashboardController = containerDiagram.RESTfulAPI.AddComponent("Dashboard Controller", "RESTful API endpoints de dashboard.", "Spring Boot REST Controller");

            AuthenticationService = containerDiagram.RESTfulAPI.AddComponent("Authentication Service", "Provee métodos de autenticación.", "Spring Boot Service");
            SpecialistService = containerDiagram.RESTfulAPI.AddComponent("Specialist Service", "Provee métodos de especialistas.", "Spring Boot Service");
            GuardianService = containerDiagram.RESTfulAPI.AddComponent("Guardian Service", "Provee métodos de cuidadores.", "Spring Boot Service");
            ChildService = containerDiagram.RESTfulAPI.AddComponent("Child Service", "Provee métodos de niños.", "Spring Boot Service");
            ObservationService = containerDiagram.RESTfulAPI.AddComponent("Observation Service", "Provee métodos de observaciones.", "Spring Boot Service");
            LevelService = containerDiagram.RESTfulAPI.AddComponent("Level Service", "Provee métodos de niveles.", "Spring Boot Service");

            AuthenticationRepository = containerDiagram.RESTfulAPI.AddComponent("Authentication Repository", "Permite la gestión de la información de autenticación.", "Spring Boot Repository");
            SpecialistRepository = containerDiagram.RESTfulAPI.AddComponent("Specialist Repository", "Permite la gestión de la información de especialistas.", "Spring Boot Repository");
            GuardianRepository = containerDiagram.RESTfulAPI.AddComponent("Guardian Repository", "Permite la gestión de la información de cuidadores.", "Spring Boot Repository");
            ChildRepository = containerDiagram.RESTfulAPI.AddComponent("Child Repository", "Permite la gestión de la información de niños.", "Spring Boot Repository");
            ObservationRepository = containerDiagram.RESTfulAPI.AddComponent("Observation Repository", "Permite la gestión de la información de observaciones.", "Spring Boot Repository");
            LevelRepository = containerDiagram.RESTfulAPI.AddComponent("Level Repository", "Permite la gestión de la información de niveles.", "Spring Boot Repository");

            EmailSystemFacade = containerDiagram.RESTfulAPI.AddComponent("Email System Facade", "", "Spring Boot");
            SpecialistValidationFacade = containerDiagram.RESTfulAPI.AddComponent("Specialist Validation Facade", "", "Spring Boot");
        }

        private void AddRelationships()
        {
            containerDiagram.MobileApplication.Uses(containerDiagram.RESTfulAPI, "", "JSON/HTTPS");
            containerDiagram.SinglePageApplication.Uses(containerDiagram.RESTfulAPI, "", "JSON/HTTPS");

            AuthenticationController.Uses(AuthenticationService, "Usa");
            SpecialistController.Uses(SpecialistService, "Usa");
            GuardianController.Uses(GuardianService, "Usa");
            GuardianController.Uses(ChildService, "Usa");
            ChildController.Uses(ChildService, "Usa");
            ObservationController.Uses(ObservationService, "Usa");
            LevelController.Uses(LevelService, "Usa");
            DashboardController.Uses(LevelService, "Usa");

            AuthenticationService.Uses(AuthenticationRepository, "Usa");
            AuthenticationService.Uses(EmailSystemFacade, "Usa");
            SpecialistService.Uses(SpecialistRepository, "Usa");
            SpecialistService.Uses(SpecialistValidationFacade, "Usa");
            GuardianService.Uses(GuardianRepository, "Usa");
            ChildService.Uses(ChildRepository, "Usa");
            ObservationService.Uses(ObservationRepository, "Usa");
            LevelService.Uses(LevelRepository, "Usa");

            AuthenticationRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            SpecialistRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            GuardianRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            ChildRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            ObservationRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            LevelRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");

            EmailSystemFacade.Uses(contextDiagram.EmailSystem, "", "JSON/HTTPS");
            SpecialistValidationFacade.Uses(contextDiagram.SpecialistValidationSystem, "", "JSON/HTTPS");
        }

        private void ApplyStyles()
        {
            SetTags();
            Styles styles = c4.ViewSet.Configuration.Styles;
            styles.Add(new ElementStyle("Component") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
        }

        private void SetTags()
        {
            string componentTag = "Component";

            AuthenticationController.AddTags(componentTag);
            SpecialistController.AddTags(componentTag);
            GuardianController.AddTags(componentTag);
            ChildController.AddTags(componentTag);
            ObservationController.AddTags(componentTag);
            LevelController.AddTags(componentTag);
            DashboardController.AddTags(componentTag);

            AuthenticationService.AddTags(componentTag);
            SpecialistService.AddTags(componentTag);
            GuardianService.AddTags(componentTag);
            ChildService.AddTags(componentTag);
            ObservationService.AddTags(componentTag);
            LevelService.AddTags(componentTag);

            AuthenticationRepository.AddTags(componentTag);
            SpecialistRepository.AddTags(componentTag);
            GuardianRepository.AddTags(componentTag);
            ChildRepository.AddTags(componentTag);
            ObservationRepository.AddTags(componentTag);
            LevelRepository.AddTags(componentTag);

            EmailSystemFacade.AddTags(componentTag);
            SpecialistValidationFacade.AddTags(componentTag);
        }

        private void CreateView()
        {
            ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.RESTfulAPI, "Componentes", "Diagrama de componentes");
            componentView.Remove(containerDiagram.SinglePageApplication);
            componentView.Remove(containerDiagram.MobileApplication);
            componentView.Add(containerDiagram.Database);
            componentView.Add(contextDiagram.EmailSystem);
            componentView.Add(contextDiagram.SpecialistValidationSystem);
            componentView.AddAllComponents();
            componentView.DisableAutomaticLayout();
        }
    }
}