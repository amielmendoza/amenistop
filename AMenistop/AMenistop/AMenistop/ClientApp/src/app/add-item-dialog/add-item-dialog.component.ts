import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export interface StoreItems {
  id: number;
  name: string;
  sellPrice: number,
  buyPrice: number,
  quantity: number;
}

export interface StoreItemsResult {
  data: {
    id: number,
    name: string,
    sellPrice: number,
    buyPrice: number,
    quantity: number
  }
}

@Component({
  selector: 'add-item-dialog',
  templateUrl: 'add-item-dialog.component.html',
  styleUrls: ['./add-item-dialog.component.css']
})
export class AddItemDialogComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  storeItem!: StoreItems;
  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    public dialogRef: MatDialogRef<AddItemDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: StoreItems,
    private fb: FormBuilder
  ) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, [Validators.required]],
      sellPrice: [null, [Validators.required]],
      buyPrice: [null, [Validators.required]],
      quantity: [null, [Validators.required]],
    });
  }

  saveDetails(form: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'my-auth-token'
      })
    };

    this.storeItem = {
      id: 0,
      name: form.value.name,
      sellPrice: form.value.sellPrice,
      buyPrice: form.value.buyPrice,
      quantity: form.value.quantity,
    }


    this.http.post<StoreItemsResult>(this.baseUrl + 'api/storeitem', this.storeItem, httpOptions).subscribe(result => {
      this.storeItem.id = result.data.id;
    }, error => console.error(error));
  }
}
