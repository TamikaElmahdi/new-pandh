import { MesureComponent } from './mesure.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UpdateComponent } from './update/update.component';
import { ListComponent } from './list/list.component';
import { ListMesureComponent } from './listMesure/listMesure.component';



const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full' },
  {
    path: '', component: MesureComponent,
    children: [
      // { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      // { path: 'list', component: ListComponent },
      { path: 'list', component: ListMesureComponent },
      { path: 'update/:id', component: UpdateComponent },
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MesureRoutingModule { }
