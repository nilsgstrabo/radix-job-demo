import { Directive, ElementRef, HostListener, Input, OnInit, Output, ViewContainerRef, EventEmitter } from '@angular/core';


@Directive({
  selector: '[appSelectAndClick]'
})
export class SelectAndClickDirective {
  @Output('areaSelected') areaSelected = new EventEmitter<any>();
  @Input('selectorItem') selectorItem: HTMLElement;

  @HostListener('mousemove', ['$event'])
  onMouseMove(itm: MouseEvent) {
    this.selectorItem.style.top = (itm.offsetY + 1) + "px";
    this.selectorItem.style.left = (itm.offsetX + 1) + "px";
  }

  @HostListener('click', ['$event'])
  onClick(itm: MouseEvent) {
    this.areaSelected.emit({ x: itm.offsetX, y: itm.offsetY })
  }

}
