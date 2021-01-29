import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPropComponent } from './add-edit-prop.component';

describe('AddEditPropComponent', () => {
  let component: AddEditPropComponent;
  let fixture: ComponentFixture<AddEditPropComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditPropComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
