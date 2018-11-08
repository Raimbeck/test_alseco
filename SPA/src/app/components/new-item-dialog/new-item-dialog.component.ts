import { Item } from './../../interfaces/item';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from "@angular/material";

@Component({
  selector: 'new-item-dialog',
  templateUrl: './new-item-dialog.component.html',
  styleUrls: ['./new-item-dialog.component.scss']
})
export class NewItemDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: {item: Item, actions: boolean}) { }

  ngOnInit() {
  }

}
