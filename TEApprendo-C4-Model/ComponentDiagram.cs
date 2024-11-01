using Structurizr;

namespace C4_Model_Monolith
{
    public class ComponentDiagram
    {
        private readonly C4 c4;
        private readonly ContextDiagram contextDiagram;
        private readonly ContainerDiagram containerDiagram;

        public Component SpecialistController { get; private set; } = null!;
        public Component UserLoginController { get; private set; } = null!;
        public Component GuardianController { get; private set; } = null!;
        public Component ChildController { get; private set; } = null!;
        public Component SymptomController { get; private set; } = null!;
        public Component ObservationController { get; private set; } = null!;
        public Component CustomLevelListController { get; private set; } = null!;
        public Component LevelController { get; private set; } = null!;
        public Component LevelRecordController { get; private set; } = null!;
        public Component TopicController { get; private set; } = null!;
        public Component CategoryController { get; private set; } = null!;

        public Component SpecialistService { get; private set; } = null!;
        public Component UserLoginService { get; private set; } = null!;
        public Component GuardianService { get; private set; } = null!;
        public Component ChildService { get; private set; } = null!;
        public Component SymptomService { get; private set; } = null!;
        public Component ObservationService { get; private set; } = null!;
        public Component CustomLevelListService { get; private set; } = null!;
        public Component LevelService { get; private set; } = null!;
        public Component LevelRecordService { get; private set; } = null!;
        public Component TopicService { get; private set; } = null!;
        public Component CategoryService { get; private set; } = null!;

        public Component SpecialistRepository { get; private set; } = null!;
        public Component UserLoginRepository { get; private set; } = null!;
        public Component GuardianRepository { get; private set; } = null!;
        public Component ChildRepository { get; private set; } = null!;
        public Component SymptomRepository { get; private set; } = null!;
        public Component ObservationRepository { get; private set; } = null!;
        public Component CustomLevelListRepository { get; private set; } = null!;
        public Component LevelRepository { get; private set; } = null!;
        public Component LevelRecordRepository { get; private set; } = null!;
        public Component TopicRepository { get; private set; } = null!;
        public Component CategoryRepository { get; private set; } = null!;

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
            SpecialistController = containerDiagram.RESTfulAPI.AddComponent("Specialist Controller", "RESTful API endpoints de especialistas.", "Spring Boot REST Controller");
            UserLoginController = containerDiagram.RESTfulAPI.AddComponent("UserLogin Controller", "RESTful API endpoints de usuarios.", "Spring Boot REST Controller");
            GuardianController = containerDiagram.RESTfulAPI.AddComponent("Guardian Controller", "RESTful API endpoints de cuidadores.", "Spring Boot REST Controller");
            ChildController = containerDiagram.RESTfulAPI.AddComponent("Child Controller", "RESTful API endpoints de niños.", "Spring Boot REST Controller");
            SymptomController = containerDiagram.RESTfulAPI.AddComponent("Symptom Controller", "RESTful API endpoints de síntomas.", "Spring Boot REST Controller");
            ObservationController = containerDiagram.RESTfulAPI.AddComponent("Observation Controller", "RESTful API endpoints de observaciones.", "Spring Boot REST Controller");
            CustomLevelListController = containerDiagram.RESTfulAPI.AddComponent("Custom Level List Controller", "RESTful API endpoints de listas personalizadas.", "Spring Boot REST Controller");
            LevelController = containerDiagram.RESTfulAPI.AddComponent("Level Controller", "RESTful API endpoints de niveles.", "Spring Boot REST Controller");
            LevelRecordController = containerDiagram.RESTfulAPI.AddComponent("Level Record Controller", "RESTful API endpoints de registros de niveles.", "Spring Boot REST Controller");
            TopicController = containerDiagram.RESTfulAPI.AddComponent("Topic Controller", "RESTful API endpoints de temas.", "Spring Boot REST Controller");
            CategoryController = containerDiagram.RESTfulAPI.AddComponent("Category Controller", "RESTful API endpoints de categorías.", "Spring Boot REST Controller");

            SpecialistService = containerDiagram.RESTfulAPI.AddComponent("Specialist Service", "Provee métodos de especialistas.", "Spring Boot Service");
            UserLoginService = containerDiagram.RESTfulAPI.AddComponent("UserLogin Service", "Provee métodos de usuarios.", "Spring Boot Service");
            GuardianService = containerDiagram.RESTfulAPI.AddComponent("Guardian Service", "Provee métodos de cuidadores.", "Spring Boot Service");
            ChildService = containerDiagram.RESTfulAPI.AddComponent("Child Service", "Provee métodos de niños.", "Spring Boot Service");
            SymptomService = containerDiagram.RESTfulAPI.AddComponent("Symptom Service", "Provee métodos de síntomas.", "Spring Boot Service");
            ObservationService = containerDiagram.RESTfulAPI.AddComponent("Observation Service", "Provee métodos de observaciones.", "Spring Boot Service");
            CustomLevelListService = containerDiagram.RESTfulAPI.AddComponent("Custom Level List Service", "Provee métodos de listas personalizadas.", "Spring Boot Service");
            LevelService = containerDiagram.RESTfulAPI.AddComponent("Level Service", "Provee métodos de niveles.", "Spring Boot Service");
            LevelRecordService = containerDiagram.RESTfulAPI.AddComponent("Level Record Service", "Provee métodos de registros de niveles.", "Spring Boot Service");
            TopicService = containerDiagram.RESTfulAPI.AddComponent("Topic Service", "Provee métodos de temas.", "Spring Boot Service");
            CategoryService = containerDiagram.RESTfulAPI.AddComponent("Category Service", "Provee métodos de categorías.", "Spring Boot Service");

            SpecialistRepository = containerDiagram.RESTfulAPI.AddComponent("Specialist Repository", "Permite la gestión de la información de especialistas.", "Spring Boot Repository");
            UserLoginRepository = containerDiagram.RESTfulAPI.AddComponent("UserLogin Repository", "Permite la gestión de la información de usuarios.", "Spring Boot Repository");
            GuardianRepository = containerDiagram.RESTfulAPI.AddComponent("Guardian Repository", "Permite la gestión de la información de cuidadores.", "Spring Boot Repository");
            ChildRepository = containerDiagram.RESTfulAPI.AddComponent("Child Repository", "Permite la gestión de la información de niños.", "Spring Boot Repository");
            SymptomRepository = containerDiagram.RESTfulAPI.AddComponent("Symptom Repository", "Permite la gestión de la información de síntomas.", "Spring Boot Repository");
            ObservationRepository = containerDiagram.RESTfulAPI.AddComponent("Observation Repository", "Permite la gestión de la información de observaciones.", "Spring Boot Repository");
            CustomLevelListRepository = containerDiagram.RESTfulAPI.AddComponent("Custom Level List Repository", "Permite la gestión de la información de listas personalizadas.", "Spring Boot Repository");
            LevelRepository = containerDiagram.RESTfulAPI.AddComponent("Level Repository", "Permite la gestión de la información de niveles.", "Spring Boot Repository");
            LevelRecordRepository = containerDiagram.RESTfulAPI.AddComponent("Level Record Repository", "Permite la gestión de la información de registros de niveles.", "Spring Boot Repository");
            TopicRepository = containerDiagram.RESTfulAPI.AddComponent("Topic Repository", "Permite la gestión de la información de temas.", "Spring Boot Repository");
            CategoryRepository = containerDiagram.RESTfulAPI.AddComponent("Category Repository", "Permite la gestión de la información de categorías.", "Spring Boot Repository");
        }

        private void AddRelationships()
        {
            containerDiagram.MobileApplication.Uses(containerDiagram.RESTfulAPI, "", "JSON/HTTPS");
            containerDiagram.SinglePageApplication.Uses(containerDiagram.RESTfulAPI, "", "JSON/HTTPS");

            SpecialistController.Uses(SpecialistService, "Usa");
            UserLoginController.Uses(UserLoginService, "Usa");
            UserLoginController.Uses(SpecialistService, "Usa");
            UserLoginController.Uses(GuardianService, "Usa");
            GuardianController.Uses(GuardianService, "Usa");
            GuardianController.Uses(ChildService, "Usa");
            ChildController.Uses(ChildService, "Usa");
            ChildController.Uses(SpecialistService, "Usa");
            ChildController.Uses(ObservationService, "Usa");
            SymptomController.Uses(SymptomService, "Usa");
            ObservationController.Uses(ObservationService, "Usa");
            CustomLevelListController.Uses(CustomLevelListService, "Usa");
            LevelController.Uses(LevelService, "Usa");
            LevelRecordController.Uses(LevelRecordService, "Usa");
            TopicController.Uses(TopicService, "Usa");
            TopicController.Uses(LevelService, "Usa");
            CategoryController.Uses(CategoryService, "Usa");
            CategoryController.Uses(TopicService, "Usa");

            SpecialistService.Uses(SpecialistRepository, "Usa");
            UserLoginService.Uses(UserLoginRepository, "Usa");
            UserLoginService.Uses(contextDiagram.EmailSystem, "Usa");
            GuardianService.Uses(GuardianRepository, "Usa");
            GuardianService.Uses(UserLoginRepository, "Usa");
            ChildService.Uses(ChildRepository, "Usa");
            ChildService.Uses(GuardianRepository, "Usa");
            ChildService.Uses(contextDiagram.EmailSystem, "Usa");
            ChildService.Uses(contextDiagram.SpecialistValidationSystem, "Usa");
            SymptomService.Uses(SymptomRepository, "Usa");
            ObservationService.Uses(ObservationRepository, "Usa");
            ObservationService.Uses(ChildRepository, "Usa");
            CustomLevelListService.Uses(CustomLevelListRepository, "Usa");
            CustomLevelListService.Uses(LevelRepository, "Usa");
            LevelService.Uses(LevelRepository, "Usa");
            LevelRecordService.Uses(LevelRecordRepository, "Usa");
            LevelRecordService.Uses(LevelRepository, "Usa");
            LevelRecordService.Uses(TopicRepository, "Usa");
            LevelRecordService.Uses(CategoryRepository, "Usa");
            TopicService.Uses(TopicRepository, "Usa");
            CategoryService.Uses(CategoryRepository, "Usa");

            SpecialistRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            UserLoginRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            GuardianRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            ChildRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            SymptomRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            ObservationRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            CustomLevelListRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            LevelRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            LevelRecordRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            TopicRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
            CategoryRepository.Uses(containerDiagram.Database, "Lee desde y escribe hacia");
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

            SpecialistController.AddTags(componentTag);
            UserLoginController.AddTags(componentTag);
            GuardianController.AddTags(componentTag);
            ChildController.AddTags(componentTag);
            ObservationController.AddTags(componentTag);
            CustomLevelListController.AddTags(componentTag);
            LevelController.AddTags(componentTag);
            LevelRecordController.AddTags(componentTag);
            TopicController.AddTags(componentTag);
            CategoryController.AddTags(componentTag);

            SpecialistService.AddTags(componentTag);
            UserLoginService.AddTags(componentTag);
            GuardianService.AddTags(componentTag);
            ChildService.AddTags(componentTag);
            SymptomService.AddTags(componentTag);
            ObservationService.AddTags(componentTag);
            CustomLevelListService.AddTags(componentTag);
            LevelService.AddTags(componentTag);
            LevelRecordService.AddTags(componentTag);
            TopicService.AddTags(componentTag);
            CategoryService.AddTags(componentTag);

            SpecialistRepository.AddTags(componentTag);
            UserLoginRepository.AddTags(componentTag);
            GuardianRepository.AddTags(componentTag);
            ChildRepository.AddTags(componentTag);
            SymptomRepository.AddTags(componentTag);
            ObservationRepository.AddTags(componentTag);
            CustomLevelListRepository.AddTags(componentTag);
            LevelRepository.AddTags(componentTag);
            LevelRecordRepository.AddTags(componentTag);
            TopicRepository.AddTags(componentTag);
            CategoryRepository.AddTags(componentTag);
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