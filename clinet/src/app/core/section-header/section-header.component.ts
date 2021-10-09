import { BreadcrumbService } from 'xng-breadcrumb';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent implements OnInit {
   breadcrumb$: Observable<any[]>;
  constructor(private brc:BreadcrumbService) { }

  ngOnInit(): void {
    this.breadcrumb$ =this.brc.breadcrumbs$;
  }

}