//
//  ProveedorMapaViewController.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ProveedorMapaViewController.h"

@interface ProveedorMapaViewController ()

@end

@implementation ProveedorMapaViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andProveedor:(Servicio*)aProveedor
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        proveedor = aProveedor;
        self.title = proveedor.Nombre;
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    mapView.showsUserLocation = YES;
    [mapView addAnnotation: proveedor]; 
    
    // Do any additional setup after loading the view from its nib.
}

- (void)viewDidUnload
{
    mapView = nil;
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}

#pragma mark - Map Delegate

- (MKAnnotationView *)mapView:(MKMapView *)aMapView viewForAnnotation:(id <MKAnnotation>)annotation{
    if ([annotation isKindOfClass:[Servicio class]])
        {
        static NSString* Annotationdentifier =@"annotation";
        MKPinAnnotationView* annoView =  (MKPinAnnotationView*)[aMapView    dequeueReusableAnnotationViewWithIdentifier: Annotationdentifier];
        if (!annoView) {
            annoView = [[MKPinAnnotationView alloc]initWithAnnotation:annotation reuseIdentifier:   Annotationdentifier];
            annoView.pinColor =  MKPinAnnotationColorRed;
            annoView.canShowCallout = YES;
        }
        return annoView;
    }
    return nil;
}

@end
