function Customer() {
    this.CUSTOMERNAME = "Trupti";
    this.MOBILENO = "9988888884";
    this.ADDRESS = "Nagpur";
}

function Factory() {
    return {
        createCustomer: function () {
            return new Customer()
        }
    }
}