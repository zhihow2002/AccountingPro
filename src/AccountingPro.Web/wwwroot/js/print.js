window.printUtils = {
  printInvoice: function (invoiceHtml) {
    console.log("printInvoice called with HTML length:", invoiceHtml ? invoiceHtml.length : "null");

    if (!invoiceHtml || typeof invoiceHtml !== "string") {
      console.error("printInvoice requires an HTML string");
      alert("Error: No invoice data to print");
      return;
    }

    if (invoiceHtml.trim().length === 0) {
      console.error("printInvoice received empty HTML string");
      alert("Error: Invoice HTML is empty");
      return;
    }

    console.log("Opening print window...");
    try {
      const printWindow = window.open("", "_blank", "width=800,height=600,scrollbars=yes,resizable=yes");
      if (!printWindow) {
        alert("Please allow popups for this site to print invoices. You can also right-click and select 'Print' from your browser menu.");
        return;
      }

      const template = `<!DOCTYPE html>
        <html>
        <head>
            <meta charset="utf-8" />
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
          <div style="border: 1px solid #ccc; padding: 20px; margin: 20px;">
            ${invoiceHtml}
          </div>
          <div style="text-align: center; margin-top: 20px;">
            <button onclick="window.print()" style="padding: 10px 20px; background: #007bff; color: white; border: none; border-radius: 4px; cursor: pointer;">Print Invoice</button>
            <button onclick="window.close()" style="padding: 10px 20px; background: #6c757d; color: white; border: none; border-radius: 4px; cursor: pointer; margin-left: 10px;">Close</button>
          </div>
        </body>
        </html>`;

      console.log("Writing HTML to print window...");
      printWindow.document.open();
      printWindow.document.write(template);
      printWindow.document.close();

      printWindow.focus();
      console.log("Print window opened successfully");
    } catch (error) {
      console.error("Error opening print window:", error);
      alert("Error opening print window: " + error.message + "\n\nTry right-clicking on the page and selecting 'Print' from the browser menu.");
    }
  },

  testFunction: function () {
    alert("JavaScript is working!");
  },

  testPrint: function () {
    const testHtml = "<h1>Test Invoice</h1><p>This is a test to see if printing works.</p>";
    this.printInvoice(testHtml);
  },
};
