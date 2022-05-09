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

			if (this.ValorTransferencia <= 0) {
				Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido.");
				return;
			}

			if (this.ValorTransferencia > Emissor.Saldo) {
				Console.WriteLine("Sua transferência não foi completada pois não há saldo suficiente na conta.");
				return;
			}

			if (Emissor.NumeroConta == Receptor.NumeroConta) {
				Console.WriteLine("Sua transferência não foi completada pois não é possível fazer transferências para uma mesma conta.");
				return;
			}

			switch (this.TipoTransferencia) {

				case "PIX":
					if (this.ValorTransferencia > 5000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência PIX.");
						return;
					}
					else break;

				case "TED":
					if (this.ValorTransferencia <= 5000 || this.ValorTransferencia > 10000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência TED.");
						return;
					}
					else break;

				case "DOC":
					if (this.ValorTransferencia <= 10000) {
						Console.WriteLine("Sua transferência não foi completada pois o valor informado é inválido para a modalidade de transferência DOC.");
						return;
					}
					else break;
			}

			Emissor.Saldo -= this.ValorTransferencia;
			Receptor.Saldo += this.ValorTransferencia;
			Console.WriteLine("Sua transferência foi realizada com sucesso!");
			Console.WriteLine("Saldo do emissor: " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Emissor.Saldo));
			Console.WriteLine("Saldo do receptor: " + string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Receptor.Saldo));

		}

	}

}
