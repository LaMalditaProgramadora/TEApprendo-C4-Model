using Structurizr;

namespace C4_Model_Monolith
{
    public class ComponentDiagram
    {
        private readonly C4 c4;
        private readonly ContextDiagram contextDiagram;
        private readonly ContainerDiagram containerDiagram;

        public Component LevelController { get; private set; } = null!;

        public Component LevelApplicationService { get; private set; } = null!;

        public Component LevelRepository { get; private set; } = null!;
        public Component LevelRecordRepository { get; private set; } = null!;
        public Component LevelListRepository { get; private set; } = null!;

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
            LevelController = containerDiagram.LevelMicroservice.AddComponent("Level Controller", "RESTful API endpoints de niveles.", "Spring Boot REST Controller");

            LevelApplicationService = containerDiagram.LevelMicroservice.AddComponent("Level Application Service", "Provee métodos de niveles.", "Spring Boot Service");

            LevelRepository = containerDiagram.LevelMicroservice.AddComponent("Level Repository", "Permite la gestión de la información de niveles.", "Spring Boot Repository");
            LevelRecordRepository = containerDiagram.LevelMicroservice.AddComponent("Level Record Repository", "Permite la gestión de la información de resultados de niveles.", "Spring Boot Repository");
            LevelListRepository = containerDiagram.LevelMicroservice.AddComponent("Level List Repository", "Permite la gestión de la información de listas de niveles.", "Spring Boot Repository");
        }

        private void AddRelationships()
        {
            containerDiagram.ApiGateway.Uses(LevelController, "", "JSON/HTTPS");
            LevelController.Uses(LevelApplicationService, "", "Usa");

            LevelApplicationService.Uses(LevelRepository, "Usa");
            LevelApplicationService.Uses(LevelRecordRepository, "Usa");
            LevelApplicationService.Uses(LevelListRepository, "Usa");

            LevelRepository.Uses(containerDiagram.LevelDatabase, "Lee desde y escribe hacia");
            LevelRepository.Uses(containerDiagram.LevelReplicaDatabase, "Lee desde y escribe hacia");
            LevelRecordRepository.Uses(containerDiagram.LevelDatabase, "Lee desde y escribe hacia");
            LevelRecordRepository.Uses(containerDiagram.LevelReplicaDatabase, "Lee desde y escribe hacia");
            LevelRecordRepository.Uses(containerDiagram.LevelReactiveDatabase, "Lee desde y escribe hacia");
            LevelListRepository.Uses(containerDiagram.LevelDatabase, "Lee desde y escribe hacia");
            LevelListRepository.Uses(containerDiagram.LevelReplicaDatabase, "Lee desde y escribe hacia");
        }

        private void ApplyStyles()
        {
            SetTags();
            Styles styles = c4.ViewSet.Configuration.Styles;

            styles.Add(new ElementStyle(nameof(LevelController)) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });

            styles.Add(new ElementStyle(nameof(LevelApplicationService)) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });

            styles.Add(new ElementStyle(nameof(LevelRepository)) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelRecordRepository)) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelListRepository)) { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
        }

        private void SetTags()
        {
            LevelController.AddTags(nameof(LevelController));

            LevelApplicationService.AddTags(nameof(LevelApplicationService));

            LevelRepository.AddTags(nameof(LevelRepository));
            LevelRecordRepository.AddTags(nameof(LevelRecordRepository));
            LevelListRepository.AddTags(nameof(LevelListRepository));
        }

        private void CreateView()
        {
            ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.LevelMicroservice, "Componentes", "Diagrama de componentes");
            componentView.Add(containerDiagram.SinglePageApplication);
            componentView.Add(containerDiagram.MobileApplication);
            componentView.Add(containerDiagram.ApiGateway);
            componentView.Add(containerDiagram.LevelDatabase);
            componentView.Add(containerDiagram.LevelReplicaDatabase);
            componentView.Add(containerDiagram.LevelReactiveDatabase);
            componentView.AddAllComponents();
            componentView.DisableAutomaticLayout();
        }
    }
}