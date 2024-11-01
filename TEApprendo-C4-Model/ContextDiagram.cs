using Structurizr;

namespace C4_Model_Monolith
{
	public class ContextDiagram
	{
		private readonly C4 c4;

		public SoftwareSystem TEApprendoSystem { get; private set; } = null!;
		public SoftwareSystem EmailSystem { get; private set; } = null!;
		public SoftwareSystem SpecialistValidationSystem { get; private set; } = null!;

		public Person Guardian { get; private set; } = null!;
		public Person Specialist { get; private set; } = null!;
        public Person Developer { get; private set; } = null!;

        public ContextDiagram(C4 c4)
		{
			this.c4 = c4;
		}

		public void Generate() {
			AddSoftwareSystems();
			AddPeople();
			AddRelationships();
			ApplyStyles();
			CreateView();
		}

		private void AddSoftwareSystems()
		{
            TEApprendoSystem = c4.Model.AddSoftwareSystem("TEApprendo", "Aplicación con Realidad Aumentada para mejorar el aprendizaje de niños con TEA.");
            EmailSystem = c4.Model.AddSoftwareSystem("Email System", "Sistema de correos de Google.");
            SpecialistValidationSystem = c4.Model.AddSoftwareSystem("Specialist Validation System", "Permite validar el código profesional del especialista.");
		}

		private void AddPeople()
		{
            Guardian = c4.Model.AddPerson("Cuidador", "Padre o apoderado del niño con TEA.");
			Specialist = c4.Model.AddPerson("Especialista", "Psicólogo o Profesor.");
			Developer = c4.Model.AddPerson("Developer", "Desarrollador de la aplicación");
		}

		private void AddRelationships() {
            Guardian.Uses(TEApprendoSystem, "Registra niño, gestiona perfil, visualiza niveles.");
            Specialist.Uses(TEApprendoSystem, "Monitorea los resultados del niño");
			Developer.Uses(TEApprendoSystem, "Realiza consultas a la REST API para probar las funcionalidades de la aplicación.");

            TEApprendoSystem.Uses(EmailSystem, "Envía correos usando");
            TEApprendoSystem.Uses(SpecialistValidationSystem, "Valida al especialista usando");
		}

		private void ApplyStyles() {
			SetTags();

			Styles styles = c4.ViewSet.Configuration.Styles;
			
			styles.Add(new ElementStyle(nameof(TEApprendoSystem)) { Background = "#008f39", Color = "#ffffff", Shape = Shape.RoundedBox });
			styles.Add(new ElementStyle(nameof(EmailSystem)) { Background = "#90714c", Color = "#ffffff", Shape = Shape.RoundedBox });
			styles.Add(new ElementStyle(nameof(SpecialistValidationSystem)) { Background = "#2f95c7", Color = "#ffffff", Shape = Shape.RoundedBox });

			styles.Add(new ElementStyle(nameof(Guardian)) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });
			styles.Add(new ElementStyle(nameof(Specialist)) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });
			styles.Add(new ElementStyle(nameof(Developer)) { Background = "#0a60ff", Shape = Shape.Robot });
		}

		private void SetTags()
		{
            TEApprendoSystem.AddTags(nameof(TEApprendoSystem));
            EmailSystem.AddTags(nameof(EmailSystem));
            SpecialistValidationSystem.AddTags(nameof(SpecialistValidationSystem));

            Guardian.AddTags(nameof(Guardian));
            Specialist.AddTags(nameof(Specialist));
			Developer.AddTags(nameof(Developer));
		}

		private void CreateView() {
			SystemContextView contextView = c4.ViewSet.CreateSystemContextView(TEApprendoSystem, "Contexto", "Diagrama de contexto");
			contextView.AddAllSoftwareSystems();
			contextView.AddAllPeople();
			contextView.DisableAutomaticLayout();
		}
	}
}