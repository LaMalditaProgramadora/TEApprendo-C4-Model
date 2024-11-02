using Structurizr;

namespace C4_Model_Monolith
{
	public class ContainerDiagram
	{
		private readonly C4 c4;
		private readonly ContextDiagram contextDiagram;

		public Container MobileApplication { get; private set; } = null!;
		public Container SinglePageApplication { get; private set; } = null!;
		
		public Container ApiGateway { get; private set; } = null!;

        public Container AuthenticationMicroservice { get; private set; } = null!;
        public Container SpecialistMicroservice { get; private set; } = null!;
        public Container GuardianMicroservice { get; private set; } = null!;
        public Container ChildMicroservice { get; private set; } = null!;
        public Container LevelMicroservice { get; private set; } = null!;
        public Container ObservationMicroservice { get; private set; } = null!;

        public Container AuthenticationDatabase { get; private set; } = null!;
        public Container SpecialistDatabase { get; private set; } = null!;
        public Container GuardianDatabase { get; private set; } = null!;
        public Container ChildDatabase { get; private set; } = null!;
        public Container LevelDatabase { get; private set; } = null!;
        public Container LevelReplicaDatabase { get; private set; } = null!;
        public Container LevelReactiveDatabase { get; private set; } = null!;
        public Container ObservationDatabase { get; private set; } = null!;

        public ContainerDiagram(C4 c4, ContextDiagram contextDiagram)
		{
			this.c4 = c4;
			this.contextDiagram = contextDiagram;
		}

		public void Generate() {
			AddContainers();
			AddRelationships();
			ApplyStyles();
			CreateView();
		}

		private void AddContainers()
		{
			MobileApplication = contextDiagram.TEApprendoSystem.AddContainer("Mobile App", "Provee las funcionalidades para la gestión de la cuenta del niño y visualización de niveles.", "C#, Unity");
			SinglePageApplication = contextDiagram.TEApprendoSystem.AddContainer("Single Page App", "Provee las funcionalidades para el monitoreo de los resultados del niño.", "Javascript, React");

            ApiGateway = contextDiagram.TEApprendoSystem.AddContainer("API Gateway", "API Gateway", "Spring Boot");

            AuthenticationMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Authentication Microservice", "Microservicio de Autenticación.", "Spring Boot");
            SpecialistMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Specialist Microservice", "Microservicio de Especialista.", "Spring Boot");
            GuardianMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Guardian Microservice", "Microservicio de Cuidador.", "Spring Boot");
            ChildMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Child Microservice", "Microservicio de Niño.", "Spring Boot");
            LevelMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Level Microservice", "Microservicio de Nivel.", "Spring Boot");
            ObservationMicroservice = contextDiagram.TEApprendoSystem.AddContainer("Observation Microservice", "Microservicio de Observaciones.", "Spring Boot");

            AuthenticationDatabase = contextDiagram.TEApprendoSystem.AddContainer("Authentication Database", "Almacena información de autenticación.", "MongoDB");
            SpecialistDatabase = contextDiagram.TEApprendoSystem.AddContainer("Specialist Database", "Almacena información de especialistas.", "MongoDB");
            GuardianDatabase = contextDiagram.TEApprendoSystem.AddContainer("Guardian Database", "Almacena información de cuidadores.", "MongoDB");
            ChildDatabase = contextDiagram.TEApprendoSystem.AddContainer("Child Database", "Almacena información de niño.", "MongoDB");
            LevelDatabase = contextDiagram.TEApprendoSystem.AddContainer("Level Database", "Almacena información de niveles.", "MongoDB");
            LevelReplicaDatabase = contextDiagram.TEApprendoSystem.AddContainer("Level Replica Database", "Almacena información de niveles.", "MongoDB");
            LevelReactiveDatabase = contextDiagram.TEApprendoSystem.AddContainer("Level Reactive Database", "Almacena información de niveles.", "MongoDB");
            ObservationDatabase = contextDiagram.TEApprendoSystem.AddContainer("Observation Database", "Almacena información de observaciones.", "MongoDB");
        }

        private void AddRelationships() {
			contextDiagram.Guardian.Uses(MobileApplication, "Usa");
			contextDiagram.Specialist.Uses(SinglePageApplication, "Usa");
			contextDiagram.Developer.Uses(ApiGateway, "API Request", "JSON/HTTPS");

			MobileApplication.Uses(ApiGateway, "API Request", "JSON/HTTPS");
			SinglePageApplication.Uses(ApiGateway, "API Request", "JSON/HTTPS");

            ApiGateway.Uses(AuthenticationMicroservice, "API Request", "JSON/HTTPS");
            ApiGateway.Uses(SpecialistMicroservice, "API Request", "JSON/HTTPS");
            ApiGateway.Uses(GuardianMicroservice, "API Request", "JSON/HTTPS");
            ApiGateway.Uses(ChildMicroservice, "API Request", "JSON/HTTPS");
            ApiGateway.Uses(LevelMicroservice, "API Request", "JSON/HTTPS");
            ApiGateway.Uses(ObservationMicroservice, "API Request", "JSON/HTTPS");

            AuthenticationMicroservice.Uses(AuthenticationDatabase, "", "JDBC");
            SpecialistMicroservice.Uses(SpecialistDatabase, "", "JDBC");
            GuardianMicroservice.Uses(GuardianDatabase, "", "JDBC");
            ChildMicroservice.Uses(ChildDatabase, "", "JDBC");
            LevelMicroservice.Uses(LevelDatabase, "", "JDBC");
            LevelMicroservice.Uses(LevelReactiveDatabase, "", "");
            LevelMicroservice.Uses(LevelReplicaDatabase, "Replica", "JDBC");
            ObservationMicroservice.Uses(ObservationDatabase, "", "JDBC");

            AuthenticationMicroservice.Uses(contextDiagram.EmailSystem, "API Request", "JSON/HTTPS");
            SpecialistMicroservice.Uses(contextDiagram.SpecialistValidationSystem, "API Request", "JSON/HTTPS");
		}

		private void ApplyStyles() {
			SetTags();

			Styles styles = c4.ViewSet.Configuration.Styles;

			styles.Add(new ElementStyle(nameof(MobileApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.MobileDevicePortrait, Icon = "" });
			styles.Add(new ElementStyle(nameof(SinglePageApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
            styles.Add(new ElementStyle(nameof(ApiGateway)) { Shape = Shape.RoundedBox, Background = "#0000ff", Color = "#ffffff", Icon = "" });

            styles.Add(new ElementStyle(nameof(AuthenticationMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(GuardianMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(SpecialistMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(ChildMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle(nameof(ObservationMicroservice)) { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });

            styles.Add(new ElementStyle(nameof(AuthenticationDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(GuardianDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(SpecialistDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelReplicaDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(LevelReactiveDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(ChildDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle(nameof(ObservationDatabase)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
        }

        private void SetTags()
		{
			MobileApplication.AddTags(nameof(MobileApplication));
			SinglePageApplication.AddTags(nameof(SinglePageApplication));
			ApiGateway.AddTags(nameof(ApiGateway));

            AuthenticationMicroservice.AddTags(nameof(AuthenticationMicroservice));
            SpecialistMicroservice.AddTags(nameof(SpecialistMicroservice));
            GuardianMicroservice.AddTags(nameof(GuardianMicroservice));
            ChildMicroservice.AddTags(nameof(ChildMicroservice));
            LevelMicroservice.AddTags(nameof(LevelMicroservice));
            ObservationMicroservice.AddTags(nameof(ObservationMicroservice));
            ObservationMicroservice.AddTags(nameof(ObservationMicroservice));

            AuthenticationDatabase.AddTags(nameof(AuthenticationDatabase));
            SpecialistDatabase.AddTags(nameof(SpecialistDatabase));
            GuardianDatabase.AddTags(nameof(GuardianDatabase));
            ChildDatabase.AddTags(nameof(ChildDatabase));
            LevelDatabase.AddTags(nameof(LevelDatabase));
            LevelReplicaDatabase.AddTags(nameof(LevelReplicaDatabase));
            LevelReactiveDatabase.AddTags(nameof(LevelReactiveDatabase));
            ObservationDatabase.AddTags(nameof(ObservationDatabase));
        }

		private void CreateView() {
			ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.TEApprendoSystem, "Contenedor", "Diagrama de contenedores");
			containerView.AddAllElements();
			containerView.DisableAutomaticLayout();
		}
	}
}