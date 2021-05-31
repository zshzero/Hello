import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Order, OrderItem } from "../shared/Order";
import { Product } from "../shared/Product";

@Injectable()
export class store {

    constructor(private http: HttpClient) {

    }

    public products : Product[] = [];

    public order: Order = new Order();

    loadProducts(): Observable<void> {
        return this.http.get<[]>("/api/products")
                .pipe(map( data => 
                    {
                        this.products = data; 
                        return;
                    }
                    ));
    }

    addToOrder(product: Product) {

        let item: OrderItem | undefined;

        item = this.order.items.find( o => o.productId === product.id);

        if(item)
            item.quantity++;
        else {
            item = new OrderItem();
            item.quantity = 1;
            item.unitPrice = product.price;
            item.productId = product.id;
            item.productCategory = product.category;
            item.productSize = product.size;
            item.productTitle = product.title;
            item.productArtist = product.artist;
            item.productArtid = product.artId;
            
            this.order.items.push(item);
        }
    }
}