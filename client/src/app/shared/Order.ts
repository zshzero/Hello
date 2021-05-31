export class OrderItem {
    id!: number;
    quantity!: number;
    unitPrice!: number;
    productId!: number;
    productCategory!: String;
    productSize!: String;
    productTitle!: String;
    productArtist!: String;
    productArtid!: String;
}

export class Order {
    orderId!: number;
    orderDate: Date = new Date();
    orderNumber!: String;
    items: OrderItem[] = [];

    get subTotal(): number {
        const result = this.items.reduce(
            (tot, val) => {
                return tot + (val.unitPrice * val.quantity);
            }, 0
        );        
        return result;
    }
}