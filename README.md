# SistemaBanco
Sistema que realiza cadastro de Bancos e boletos para pagar

## Entrada de dados dos Endpoints para cadastro:

### /api/Bancos

{
  "bancoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nomeDoBanco": "string",
  "codigoDoBanco": "string",
  "percentualDeJuros": 0
}

### /api/Boletos

{
  "boletoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6", (Guid)
  "nomeDoPagador": "string",
  "cpfDoPagador": "string",
  "nomeDoBeneficiario": "string",
  "cpfDoBeneficiario": "string",
  "valor": 0, (decimal)
  "dataDeVencimento": "2025-09-09", (dateTime formato yyyy-MM-dd)
  "observacao": "string",
  "bancoId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" (Guid)
}
