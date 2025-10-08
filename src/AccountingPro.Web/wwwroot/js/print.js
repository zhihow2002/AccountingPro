window.printUtils = {
  printInvoice: function (invoiceHtml) {
    console.log("printInvoice function called with HTML length:", invoiceHtml.length);
    const printWindow = window.open("", "_blank");
    if (!printWindow) {
      alert("Please allow popups for this site to print invoices.");
      return;
    }
    printWindow.document.write(`
            <!DOCTYPE html>
            <html>
            <head>
                <title>Invoice Print</title>
                <style>
                    body { font-family: Arial, sans-serif; margin: 20px; }
                    .header { text-align: center; border-bottom: 2px solid #333; padding-bottom: 10px; margin-bottom: 20px; }
                    .invoice-details { margin-bottom: 20px; }
                    .invoice-details table { width: 100%; border-collapse: collapse; }
                    .invoice-details td { padding: 5px; }
                    .items-table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                    .items-table th, .items-table td { border: 1px solid #ddd; padding: 8px; text-align: left; }
                    .items-table th { background-color: #f2f2f2; }
                    .total { text-align: right; margin-top: 20px; font-weight: bold; }
                    @media print { body { margin: 0; } }
                </style>
            </head>
            <body>
                ${invoiceHtml}
            </body>
            </html>
        `);
    printWindow.document.close();
    printWindow.focus();
    
    // Add a small delay to ensure content is loaded
    setTimeout(() => {
      printWindow.print();
      printWindow.close();
    }, 500);
  },
  
  testFunction: function() {
    alert("JavaScript is working!");
  }
};
