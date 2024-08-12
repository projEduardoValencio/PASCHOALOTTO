import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.scss'
})
export class UserDetailComponent implements OnInit{
  public id?: number
  constructor(private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    if(this.route.snapshot.paramMap.get('id')){
      this.id = parseInt(this.route.snapshot.paramMap.get('id')!)
    }else{
      this.router.navigate(['/']);
    }
  }
}
