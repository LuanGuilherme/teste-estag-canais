namespace teste_estag_canais.Classes {

	public class Conta {

		private string Nome { get; set; }

		private string Agencia { get; set; }

		public string NumeroConta { get; set; }

		private string CPF { get; }

		public double Saldo { get; set; }

		public Conta (string Nome, string Agencia, string Conta, string CPF, double Saldo) {

			this.Nome = Nome;
			this.Agencia = Agencia;
			this.NumeroConta = Conta;
			this.CPF = CPF;
			this.Saldo = Saldo;

		}

	}

}
