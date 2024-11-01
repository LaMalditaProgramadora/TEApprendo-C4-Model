using Structurizr;

namespace C4_Model_Monolith
{
	public class ContainerDiagram
	{
		private readonly C4 c4;
		private readonly ContextDiagram contextDiagram;

		public Container MobileApplication { get; private set; } = null!;
		public Container SinglePageApplication { get; private set; } = null!;
		public Container RESTfulAPI { get; private set; } = null!;

		public Container Database { get; private set; } = null!;

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

			RESTfulAPI = contextDiagram.TEApprendoSystem.AddContainer("RESTful API", "Provee las funcionalidades de TEApprendo via RESTful API.", "Java, Spring Boot");
			
			Database = contextDiagram.TEApprendoSystem.AddContainer("Database", "Almacena información del cuidador, niño y especialista, así como de los niveles.", "MongoDB");
		}

		private void AddRelationships() {
			contextDiagram.Guardian.Uses(MobileApplication, "Usa");

			contextDiagram.Specialist.Uses(SinglePageApplication, "Usa");

			contextDiagram.Developer.Uses(RESTfulAPI, "API Request", "JSON/HTTPS");

			MobileApplication.Uses(RESTfulAPI, "API Request", "JSON/HTTPS");

			SinglePageApplication.Uses(RESTfulAPI, "API Request", "JSON/HTTPS");

			RESTfulAPI.Uses(Database, "", "JDBC");

			RESTfulAPI.Uses(contextDiagram.EmailSystem, "API Request", "JSON/HTTPS");
			RESTfulAPI.Uses(contextDiagram.SpecialistValidationSystem, "API Request", "JSON/HTTPS");
		}

		private void ApplyStyles() {
			SetTags();

			Styles styles = c4.ViewSet.Configuration.Styles;

			styles.Add(new ElementStyle(nameof(MobileApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.MobileDevicePortrait, Icon = "" });
			styles.Add(new ElementStyle(nameof(SinglePageApplication)) { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
			styles.Add(new ElementStyle(nameof(RESTfulAPI)) { Shape = Shape.RoundedBox, Background = "#0000ff", Color = "#ffffff", Icon = "" });

			styles.Add(new ElementStyle(nameof(Database)) { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
		}

		private void SetTags()
		{
			MobileApplication.AddTags(nameof(MobileApplication));
			SinglePageApplication.AddTags(nameof(SinglePageApplication));
			RESTfulAPI.AddTags(nameof(RESTfulAPI));

			Database.AddTags(nameof(Database));
		}

		private void CreateView() {
			ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.TEApprendoSystem, "Contenedor", "Diagrama de contenedores");
			containerView.AddAllElements();
			containerView.DisableAutomaticLayout();
		}
	}
}