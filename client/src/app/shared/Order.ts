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
}