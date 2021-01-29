import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPropComponent } from './show-prop.component';

describe('ShowPropComponent', () => {
  let component: ShowPropComponent;
  let fixture: ComponentFixture<ShowPropComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPropComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowPropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
