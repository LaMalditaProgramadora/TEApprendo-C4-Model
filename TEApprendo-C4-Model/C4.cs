using Structurizr;
using Structurizr.Api;

namespace C4_Model_Monolith
{
	public class C4
	{
        private readonly long workspaceId = 0;
        private readonly string apiKey = "";
        private readonly string apiSecret = "";

        public StructurizrClient StructurizrClient { get; }
		public Workspace Workspace { get; }
		public Model Model { get; }
		public ViewSet ViewSet { get; }

		public C4()
		{
			string workspaceName = "TEApprendo";
			string workspaceDescription = "Aplicación con Realidad Aumentada para mejorar el aprendizaje de niños con TEA.";
			StructurizrClient = new StructurizrClient(apiKey, apiSecret);
			Workspace = new Workspace(workspaceName, workspaceDescription);
			Model = Workspace.Model;
			ViewSet = Workspace.Views;
		}

		public void Generate() {
			ContextDiagram contextDiagram = new(this);
			ContainerDiagram containerDiagram = new(this, contextDiagram);
			ComponentDiagram componentDiagram = new(this, contextDiagram, containerDiagram);
			contextDiagram.Generate();
			containerDiagram.Generate();
			componentDiagram.Generate();
			PutWorkspace();
		}

		private void PutWorkspace() {
			StructurizrClient.UnlockWorkspace(workspaceId);
			StructurizrClient.PutWorkspace(workspaceId, Workspace);
		}
	}
}