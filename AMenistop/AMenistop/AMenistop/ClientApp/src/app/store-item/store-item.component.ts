import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddItemDialogComponent } from '../add-item-dialog/add-item-dialog.component';
import { DeleteItemDialogComponent } from '../delete-item-dialog/delete-item-dialog.component';

export interface StoreItems {
  id: number;
  name: string;
  sellPrice: number,
  buyPrice: number,
  quantity: number;
}

export interface StoreItemsResult {
  data: StoreItems[];
  hasError: boolean;
  exception: string;
}

/**
 * @title Data table with sorting, pagination, and filtering.
 */
@Component({
  selector: 'app-store-item',
  templateUrl: './store-item.component.html',
  styleUrls: ['./store-item.component.css']
})
export class StoreItemComponent {
  public storeItems: StoreItems[] = [];

  displayedColumns = ['actions', 'name', 'sellPrice', 'buyPrice', 'quantity'];
  dataSource!: MatTableDataSource<StoreItems>;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator | null;
  @ViewChild(MatSort)
  sort!: MatSort | null;

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, public dialog: MatDialog) {
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(AddItemDialogComponent, {
      width: '20rem',
      height: '28rem',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getDataSource();
      console.log("close add")
    });
  }

  openDeleteDialog(id: number): void {
    const dialogRef = this.dialog.open(DeleteItemDialogComponent, {
      width: '20rem',
      height: '26rem',
      data: { id }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getDataSource();
      console.log("close delete")
    });
  }

  openEditDialog(): void {
    const dialogRef = this.dialog.open(AddItemDialogComponent, {
      width: '20rem',
      height: '30rem',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getDataSource();
      console.log("close edit")
    });
  }

  /**
  * Set the paginator and sort after the view init since this component will
  * be able to query its view for the initialized paginator and sort.
  */
  ngAfterViewInit() {
    this.getDataSource();
  }

  getDataSource() {
    this.http.get<StoreItemsResult>(this.baseUrl + 'api/storeitem').subscribe(result => {
      console.log(result.data)
      this.dataSource = new MatTableDataSource(result.data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }, error => console.error(error));
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

  delete(storeItem: StoreItems) {
    console.log(storeItem, "delete");
  }

  edit(storeItem: StoreItems) {
    console.log(storeItem, "edit");
  }
}
