using MySqlConnector;
using System.Data;

namespace WinFormsAppFoto
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                // Testa a conexão
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;port=3306;database=aula;user id=root;password=;charset=utf8"))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Conexão com o banco de dados bem-sucedida!", "Teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Continua com o carregamento dos dados
                CarregarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se o campo de nome está preenchido
                if (string.IsNullOrWhiteSpace(txtNome.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome antes de adicionar.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNome.Focus();
                    return;
                }

                // Verifica se uma imagem foi selecionada
                if (pbxImagem.Image == null)
                {
                    MessageBox.Show("Por favor, selecione uma imagem antes de adicionar.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Salva os dados
                Foto foto = new Foto();
                string nomeFoto = txtNome.Text.Trim().Replace(" ", ""); // Remove espaços no nome
                string caminhoImagem = $@"C:\WinFormsAppFoto\Imagens\{nomeFoto}.jpg";

                // Salva a imagem
                pbxImagem.Image.Save(caminhoImagem);

                // Adiciona ao banco de dados
                foto.Inserir(txtNome.Text.Trim(), nomeFoto);

                // Mensagem de sucesso
                MessageBox.Show("Registro adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarrega os dados no DataGridView
                CarregarDados();

                // Limpa os campos
                txtNome.Text = string.Empty;
                pbxImagem.Image = null;
                txtNome.Focus(); // Foco no campo de texto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verifica se os campos obrigatórios estão preenchidos
                if (string.IsNullOrEmpty(lblId.Text) || string.IsNullOrEmpty(txtNome.Text))
                {
                    MessageBox.Show("Por favor, selecione um registro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(lblId.Text.Trim());
                Foto foto = new Foto();

                // Busca o registro antigo na lista
                Foto fotoAntiga = foto.listafoto().FirstOrDefault(f => f.id == id);

                // Verifica se o registro foi encontrado
                if (fotoAntiga == null)
                {
                    MessageBox.Show($"Registro com o ID {id} não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Atualiza os dados
                string novoNome = txtNome.Text.Trim();
                string novoNomeFoto = novoNome.Replace(" ", ""); // Nome atualizado
                string caminhoAntigo = $@"C:\WinFormsAppFoto\Imagens\{fotoAntiga.foto}.jpg";
                string novoCaminho = $@"C:\WinFormsAppFoto\Imagens\{novoNomeFoto}.jpg";

                // Libera a imagem carregada no PictureBox
                if (pbxImagem.Image != null)
                {
                    pbxImagem.Image.Dispose();
                    pbxImagem.Image = null;
                }

                // Renomeia a imagem
                if (System.IO.File.Exists(caminhoAntigo))
                {
                    System.IO.File.Move(caminhoAntigo, novoCaminho);
                }

                // Atualiza o registro no banco
                foto.Atualizar(id, novoNome, novoNomeFoto);

                MessageBox.Show("Registro atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarrega os dados no DataGridView
                CarregarDados();
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Erro de arquivo: {ioEx.Message}. Certifique-se de que o arquivo não está em uso.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há um ID válido para exclusão
                if (string.IsNullOrEmpty(lblId.Text))
                {
                    MessageBox.Show("Por favor, selecione um registro para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmação de exclusão
                DialogResult confirm = MessageBox.Show("Tem certeza de que deseja excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No)
                {
                    return;
                }

                // Realiza a exclusão
                int id = Convert.ToInt32(lblId.Text.Trim());
                Foto foto = new Foto();
                string nomeFoto = txtNome.Text.Replace(" ", "");
                string caminhoImagem = $@"C:\WinFormsAppFoto\Imagens\{nomeFoto}.jpg";

                // Libera a imagem carregada no PictureBox
                if (pbxImagem.Image != null)
                {
                    pbxImagem.Image.Dispose();
                    pbxImagem.Image = null;

                    // Aguarda para garantir que o arquivo não esteja em uso
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                // Exclui o arquivo de imagem, se existir
                if (System.IO.File.Exists(caminhoImagem))
                {
                    System.IO.File.Delete(caminhoImagem);
                }

                // Exclui o registro do banco de dados
                foto.Excluir(id);

                // Mensagem de sucesso
                MessageBox.Show("Registro excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarrega os dados no DataGridView
                CarregarDados();

                // Verifica se ainda há registros no DataGridView
                if (dgvFoto.Rows.Count > 0)
                {
                    // Seleciona o primeiro registro
                    DataGridViewRow row = dgvFoto.Rows[0];
                    AtualizarCampos(row);
                }
                else
                {
                    // Limpa os campos do formulário
                    lblId.Text = string.Empty;
                    txtNome.Text = string.Empty;
                    pbxImagem.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Selecione uma imagem...";
            dialog.Filter = "Arquivos de Imagem|*.bmp;*jpg;*.png;*.gif|Todos os arquivos|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imagem = dialog.FileName;
                pbxImagem.ImageLocation = imagem;
            }
        }

        

        private void dgvFoto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dgvFoto.Rows[e.RowIndex];
                    AtualizarCampos(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        
        private void CarregarDados()
        {
            try
            {
                Foto foto = new Foto();
                List<Foto> fotos = foto.listafoto();

                if (fotos.Count > 0)
                {
                    dgvFoto.DataSource = null; // Limpa a origem anterior
                    dgvFoto.DataSource = fotos;

                    // Atualiza os campos com o primeiro registro
                    DataGridViewRow row = dgvFoto.Rows[0];
                    AtualizarCampos(row);
                }
                else
                {
                    dgvFoto.DataSource = null;
                    lblId.Text = string.Empty;
                    txtNome.Text = string.Empty;
                    pbxImagem.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarCampos(DataGridViewRow row)
        {
            try
            {
                lblId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();

                string nomeFoto = txtNome.Text.Replace(" ", "");
                string caminhoImagem = $@"C:\WinFormsAppFoto\Imagens\{nomeFoto}.jpg";

                if (System.IO.File.Exists(caminhoImagem))
                {
                    pbxImagem.Image = Image.FromFile(caminhoImagem);
                }
                else
                {
                    pbxImagem.Image = null;
                    MessageBox.Show("Imagem não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar os campos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarImagem(string caminho)
        {
            if (System.IO.File.Exists(caminho))
            {
                using (FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.Read))
                {
                    pbxImagem.Image = Image.FromStream(fs);
                }
            }
            else
            {
                pbxImagem.Image = null;
            }
        }

    }
}