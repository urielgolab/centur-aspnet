//
//  ProveedorMapaViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import "Servicio.h"
#import "BaseViewController.h"

@interface ProveedorMapaViewController :BaseViewController<MKMapViewDelegate>{
    IBOutlet MKMapView *mapView;
    Servicio* proveedor;
}

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andProveedor:(Servicio*)aProveedor;

@end
