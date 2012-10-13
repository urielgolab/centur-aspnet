//
//  ProveedorDetailViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Servicio.h"
#import "BaseViewController.h"

@interface ProveedorDetailViewController : BaseViewController{
    
    Servicio* proveedor;
    IBOutlet UILabel *nombreLabel;
    IBOutlet UIImageView *thumbsImage;
    IBOutlet UILabel *direccionLabel;
    IBOutlet UITextView *descripcionTextView;
    IBOutlet UIButton *pedirTurno;
    IBOutlet UIButton *mapaButton;
    
}

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andProveedor:(Servicio*)aProveedor;

@end
