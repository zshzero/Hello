import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable()
export class store {

    constructor(private http: HttpClient) {

    }

    public products : any[] = [];

    loadProducts() {
        return this.http.get<[]>("/api/products")
                .pipe(map( data => 
                    {
                        this.products = data; 
                        return;
                    }
                    ));
    }
}