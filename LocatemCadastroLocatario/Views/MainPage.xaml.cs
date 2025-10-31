namespace LocatemCadastroLocatario
{
    public partial class MainPage : ContentPage
    {
        private bool _showPassword = false;

        public MainPage()
        {
            InitializeComponent();

        }


        private async void OnTogglePassword(object sender, EventArgs e)
        {
            _showPassword = !_showPassword;
            SenhaEntry.IsPassword = !_showPassword;

        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var nome = NomeEntry.Text?.Trim();
            var email = EmailEntry.Text?.Trim();
            var senha = SenhaEntry.Text?.Trim();
            var cpf = CpfEntry.Text?.Trim();
            var endereco = EnderecoEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(cpf))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }
            // Simulação de autenticação (substitua com sua lógica real)
            if (email.Contains("0") && senha.Length >= 4)
            {
                await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
                return;
            }
            else
            {
                await DisplayAlert("Erro", "Email ou senha invalidos.", "OK");
            }

        }

        private async void OnShowTerms(object sender, EventArgs e)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Termos.txt");
            using var reader = new StreamReader(stream);

            var termos = await reader.ReadToEndAsync();
            await DisplayAlert("Termos de Servico", termos, "OK");
        }

    }
}
