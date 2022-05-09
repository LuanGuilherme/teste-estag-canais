using System;
using System.Globalization;

namespace teste_estag_canais.Classes {

	public class Transferencia {

		private int IdTransferencia { get; set; }

		private double ValorTransferencia { get; set; }

		private string TipoTransferencia { get; set; }

		public Transferencia (int IdTransferencia, double ValorTransferencia, string TipoTransferencia) {
			this.IdTransferencia = IdTransferencia;
			this.ValorTransferencia = ValorTransferencia;
			this.TipoTransferencia = TipoTransferencia;
		}

		public void FazTransferencia (Conta Emissor, Conta Receptor) {

			if (!validaDadosTransferencia(Emissor, Receptor))
				return;

			Emissor.Saldo -= this.ValorTransferencia;
			Receptor.Saldo += this.ValorTransferencia;
			Console.WriteLine("Sua transferência foi realizada com sucesso!");
			Console.WriteLine("Saldo do emissor: " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Emissor.Saldo));
			Console.WriteLine("Saldo do receptor: " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Receptor.Saldo));

		}

		private bool validaDadosTransferencia (Conta Emissor, Conta Receptor) {

			if (this.ValorTransferencia <= 0) {
				Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido.");
				return false;
			}

			if (this.ValorTransferencia > Emissor.Saldo) {
				Console.WriteLine("Sua transferência não foi completada pois não há saldo suficiente na conta.");
				return false;
			}

			if (Emissor.NumeroConta == Receptor.NumeroConta && Emissor.Agencia == Receptor.Agencia) {
				Console.WriteLine("Sua transferência não foi completada pois não é possível fazer transferências para uma mesma conta.");
				return false;
			}

			switch (this.TipoTransferencia) {

				case "PIX":
					if (this.ValorTransferencia > 5000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência PIX.");
						return false;
					}
					else break;

				case "TED":
					if (this.ValorTransferencia <= 5000 || this.ValorTransferencia > 10000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência TED.");
						return false;
					}
					else break;

				case "DOC":
					if (this.ValorTransferencia <= 10000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência DOC.");
						return false;
					}
					else break;
			}

			return true;

		}

	}

}
