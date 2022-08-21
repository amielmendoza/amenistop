import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export interface StoreItems {
  id: number;
  name: string;
  price: number;
  quantity: number;
}

export interface StoreItemsResult {
  data: {
    id: number,
    name: string,
    price: number,
    quantity: number
  }
}

@Component({
  selector: 'delete-item-dialog',
  templateUrl: 'delete-item-dialog.component.html',
  styleUrls: ['./delete-item-dialog.component.css']
})
export class DeleteItemDialogComponent implements OnInit {
  storeItem!: StoreItems;
  constructor(
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    public dialogRef: MatDialogRef<DeleteItemDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

  delete() {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'my-auth-token'
      })
    };

    this.http.delete<StoreItemsResult>(this.baseUrl + 'api/storeitem/' + this.data.id, httpOptions).subscribe(result => {
     
    }, error => console.error(error));
  }
}
