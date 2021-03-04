import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMesureComponent } from './listMesure.component';

describe('ListMesureComponent', () => {
  let component: ListMesureComponent;
  let fixture: ComponentFixture<ListMesureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListMesureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListMesureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
