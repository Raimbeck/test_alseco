import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '../../../../node_modules/@angular/material';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.scss']
})
export class ConfirmComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: {title: string, message: string}) { }

  ngOnInit() {
  }

}
