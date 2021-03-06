﻿/****************************************************************************
** Copyright (C) 2013-2015 Mazatech S.r.l. All rights reserved.
**
** This file is part of SVGAssets software, an SVG rendering engine.
**
** W3C (World Wide Web Consortium) and SVG are trademarks of the W3C.
** OpenGL is a registered trademark and OpenGL ES is a trademark of
** Silicon Graphics, Inc.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** For any information, please contact info@mazatech.com
**
****************************************************************************/
#if UNITY_2_6
    #define UNITY_2_X
    #define UNITY_2_PLUS
#elif UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
    #define UNITY_3_X
    #define UNITY_2_PLUS
    #define UNITY_3_PLUS
#elif UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9
    #define UNITY_4_X
    #define UNITY_2_PLUS
    #define UNITY_3_PLUS
    #define UNITY_4_PLUS
#elif UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9
    #define UNITY_5_X
    #define UNITY_2_PLUS
    #define UNITY_3_PLUS
    #define UNITY_4_PLUS
    #define UNITY_5_PLUS
#endif

using System;
using System.Runtime.InteropServices;
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
using SVGAssetsBridge;
#endif
using UnityEngine;

public static class AmanithSVG {
#if UNITY_EDITOR
    /* Windows editor will use libAmanithSVG.dll, Max OS X editor will use libAmanithSVG.bundle */
    private const string libName = "libAmanithSVG";
#elif UNITY_STANDALONE_WIN
    /* Windows uses libAmanithSVG.dll */
    private const string libName = "libAmanithSVG";
#elif UNITY_STANDALONE_OSX
    /* Mac OS X uses libAmanithSVG.bundle */
    private const string libName = "libAmanithSVG";
#elif UNITY_STANDALONE_LINUX
    /* Linux uses libAmanithSVG.so please note that plugin name should not include the prefix ('lib') nor the extension ('.so') of the filename */
    private const string libName = "AmanithSVG";
#elif UNITY_IPHONE
    /* On iOS, everything gets built into one big binary, so "__Internal" is the name of the library to use */
    private const string libName = "__Internal";
#elif UNITY_ANDROID
    /* Android uses libAmanithSVG.so please note that plugin name should not include the prefix ('lib') nor the extension ('.so') of the filename */
    private const string libName = "AmanithSVG";
#else
    private const string libName = "libAmanithSVG";
#endif

    /* Invalid handle. */
    public const uint SVGT_INVALID_HANDLE                   = 0;

    /* SVGTboolean */
    public const int SVGT_FALSE                             = 0;
    public const int SVGT_TRUE                              = 1;

    /*
        SVGTAspectRatioAlign

        Alignment indicates whether to force uniform scaling and, if so, the alignment method to use in case the aspect ratio of the source
        viewport doesn't match the aspect ratio of the destination (drawing surface) viewport.
    */

    /*
        Do not force uniform scaling.
        Scale the graphic content of the given element non-uniformly if necessary such that
        the element's bounding box exactly matches the viewport rectangle.
        NB: in this case, the <meetOrSlice> value is ignored.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_NONE           = 0;

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMINYMIN       = 1;

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMIDYMIN       = 2;

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMAXYMIN       = 3;

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMINYMID       = 4;

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMIDYMID       = 5;

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMAXYMID       = 6;

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMINYMAX       = 7;

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMIDYMAX       = 8;

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    public const int SVGT_ASPECT_RATIO_ALIGN_XMAXYMAX      = 9;


    /* SVGTAspectRatioMeetOrSlice */
    /*
        Scale the graphic such that:
        - aspect ratio is preserved
        - the entire viewBox is visible within the viewport
        - the viewBox is scaled up as much as possible, while still meeting the other criteria

        In this case, if the aspect ratio of the graphic does not match the viewport, some of the viewport will
        extend beyond the bounds of the viewBox (i.e., the area into which the viewBox will draw will be smaller
        than the viewport).
    */
    public const int SVGT_ASPECT_RATIO_MEET                 = 0;

    /*
        Scale the graphic such that:
        - aspect ratio is preserved
        - the entire viewport is covered by the viewBox
        - the viewBox is scaled down as much as possible, while still meeting the other criteria
        
        In this case, if the aspect ratio of the viewBox does not match the viewport, some of the viewBox will
        extend beyond the bounds of the viewport (i.e., the area into which the viewBox will draw is larger
        than the viewport).
    */
    public const int SVGT_ASPECT_RATIO_SLICE                = 1;

    /* SVGTErrorCode */
    public const int SVGT_NO_ERROR                          = 0;
    // it indicates that the library has not previously been initialized through the svgtInit() function
    public const int SVGT_NOT_INITIALIZED_ERROR             = 1;
    public const int SVGT_BAD_HANDLE_ERROR                  = 2;
    public const int SVGT_ILLEGAL_ARGUMENT_ERROR            = 3;
    public const int SVGT_OUT_OF_MEMORY_ERROR               = 4;
    public const int SVGT_PARSER_ERROR                      = 5;
    // returned when the library detects that outermost element is not an <svg> element or there is circular dependency (usually generated by <use> elements)
    public const int SVGT_INVALID_SVG_ERROR                 = 6;
    public const int SVGT_STILL_PACKING_ERROR               = 7;
    public const int SVGT_NOT_PACKING_ERROR                 = 8;
    public const int SVGT_UNKNOWN_ERROR                     = 9;

    /* SVGTRenderingQuality */    
    public const int SVGT_RENDERING_QUALITY_NONANTIALIASED  = 0;
    public const int SVGT_RENDERING_QUALITY_FASTER          = 1;
    public const int SVGT_RENDERING_QUALITY_BETTER          = 2;

    /* SVGTStringID */
    public const int SVGT_VENDOR                            = 1;
    public const int SVGT_VERSION                           = 2;

    /* Packed rectangle */
    [StructLayout(LayoutKind.Sequential)]  
    public struct SVGTPackedRect
    {
        // 'id' attribute, NULL if not present.
        public System.IntPtr elemName;
        // Original rectangle corner.
        public int originalX;
        public int originalY;
        // Rectangle corner position.
        public int x;
        public int y;
        // Rectangle dimensions.
        public int width;
        public int height;
        // Custom data: SVG document handle, group index, element name
        public uint docHandle;
        // 0 for the whole SVG, else the element (tree) index.
        public uint elemIdx;
        // Z-order.
        public int zOrder;
        //public float scale;
        public float dstViewportWidth;
        public float dstViewportHeight;
    };

    /*
        Initialize the library.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtInit(uint screenWidth,
	                           uint screenHeight,
	                           float dpi)
	{
		return SVGAssetsBridge.API.svgtInit(screenWidth, screenHeight, dpi);
	}
#else
    [DllImport(libName)]
    public static extern int svgtInit(uint screenWidth,
                                      uint screenHeight,
                                      float dpi);
#endif

    /*
        Destroy the library, freeing all allocated resources.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static void svgtDone()
	{
		SVGAssetsBridge.API.svgtDone();
	}
#else
    [DllImport(libName)]
    public static extern void svgtDone();
#endif

    /*
        Get the maximum dimension allowed for drawing surfaces.

        This is the maximum valid value that can be specified as 'width' and 'height' for the svgtSurfaceCreate and svgtSurfaceResize functions.
        Bigger values are silently clamped to it.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static uint svgtSurfaceMaxDimension()
	{
		return SVGAssetsBridge.API.svgtSurfaceMaxDimension();
	}
#else
    [DllImport(libName)]
    public static extern uint svgtSurfaceMaxDimension();
#endif

    /*
        Create a new drawing surface, specifying its dimensions in pixels.
        Specified width and height must be greater than zero.

        Return SVGT_INVALID_HANDLE in case of errors, else a valid drawing surface handle.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static uint svgtSurfaceCreate(uint width,
	                                     uint height)
	{
		return SVGAssetsBridge.API.svgtSurfaceCreate(width, height);
	}
#else
    [DllImport(libName)]
    public static extern uint svgtSurfaceCreate(uint width,
                                                uint height);
#endif

    /*
        Destroy a previously created drawing surface.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceDestroy(uint surface)
	{
		return SVGAssetsBridge.API.svgtSurfaceDestroy(surface);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceDestroy(uint surface);
#endif

    /*
        Resize a drawing surface, specifying new dimensions in pixels.
        Specified newWidth and newHeight must be greater than zero.

        After resizing, the surface viewport will be reset to the whole surface (see svgtSurfaceViewportGet / svgtSurfaceViewportSet),
        and the relative transformation will be reset to identity (pivot = [0; 0], angle = 0, post-translation = [0; 0], see
        svgtSurfaceViewportTransformGet / svgtSurfaceViewportTransformSet for details).

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceResize(uint surface,
	                                    uint newWidth,
	                                    uint newHeight)
	{
		return SVGAssetsBridge.API.svgtSurfaceResize(surface, newWidth, newHeight);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceResize(uint surface,
                                               uint newWidth,
                                               uint newHeight);
#endif

    /*
        Get width dimension (in pixels), of the specified drawing surface.
        If the specified surface handle is not valid, 0 is returned.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static uint svgtSurfaceWidth(uint surface)
	{
		return SVGAssetsBridge.API.svgtSurfaceWidth(surface);
	}
#else
    [DllImport(libName)]
    public static extern uint svgtSurfaceWidth(uint surface);
#endif

    /*
        Get height dimension (in pixels), of the specified drawing surface.
        If the specified surface handle is not valid, 0 is returned.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static uint svgtSurfaceHeight(uint surface)
	{
		return SVGAssetsBridge.API.svgtSurfaceHeight(surface);
	}
#else
    [DllImport(libName)]
    public static extern uint svgtSurfaceHeight(uint surface);
#endif

    /*
        Get access to the drawing surface pixels.
        If the specified surface handle is not valid, NULL is returned.

        Please use this function to access surface pixels for read-only purposes (e.g. blit the surface
        on the screen, according to the platform graphic subsystem, upload pixels into a GPU texture, and so on).
        Writing or modifying surface pixels by hand is still possible, but not advisable.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static System.IntPtr svgtSurfacePixels(uint surface)
	{
		return (System.IntPtr)SVGAssetsBridge.API.svgtSurfacePixels(surface);
	}
#else
    [DllImport(libName)]
    public static extern System.IntPtr svgtSurfacePixels(uint surface);
#endif

    /*
        Copy drawing surface content into the specified pixels buffer.
        This method is a shortcut for the following copy operation:

            MemCopy(dstPixels32, svgtSurfacePixels(surface), svgtSurfaceWidth(surface) * svgtSurfaceHeight(surface) * 4)

        This function is useful for managed environments (e.g. C#, Unity, Java, Android), where the use of a direct pixels
        access (i.e. svgtSurfacePixels) is not advisable nor comfortable.

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if the specified surface handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'dstPixels32' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */

#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceCopy(uint surface,
                                      Color32[] dstPixels32,
                                      int dilateEdgesFix)
	{
		int result = SVGT_NO_ERROR;
		GCHandle handle = GCHandle.Alloc(dstPixels32, GCHandleType.Pinned);

		try
		{
			IntPtr ptr = handle.AddrOfPinnedObject();
			result = SVGAssetsBridge.API.svgtSurfaceCopy(surface, ptr.ToInt64(), dilateEdgesFix);
		}
		finally
		{
			if (handle.IsAllocated)
				handle.Free();
		}

		return result;
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceCopy(uint surface,
                                             Color32[] dstPixels32,
                                             int dilateEdgesFix);
#endif

    /*
        Get current destination viewport (i.e. a drawing surface rectangular area), where to map the source document viewport.

        The 'viewport' parameter must be an array of (at least) 4 float entries, it will be filled with:
        - viewport[0] = top/left x
        - viewport[1] = top/left y
        - viewport[2] = width
        - viewport[3] = height

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified surface handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'viewport' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceViewportGet(uint surface,
	                                         float[] viewport)
	{
		return SVGAssetsBridge.API.svgtSurfaceViewportGet(surface, viewport);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceViewportGet(uint surface,
                                                    float[] viewport);
#endif

    /*
        Set destination viewport (i.e. a drawing surface rectangular area), where to map the source document viewport.

        The 'viewport' parameter must be an array of (at least) 4 float entries, it must contains:
        - viewport[0] = top/left x
        - viewport[1] = top/left y
        - viewport[2] = width
        - viewport[3] = height

        The combined use of svgtDocViewportSet and svgtSurfaceViewportSet induces a transformation matrix, that will be used
        to draw the whole SVG document. The induced matrix grants that the document viewport is mapped onto the surface
        viewport (respecting the specified alignment): all SVG content will be drawn accordingly.

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified surface handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'viewport' pointer is NULL or if it's not properly aligned
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified viewport width or height are less than or equal zero
        - SVGT_NO_ERROR if the operation was completed successfully

        NB: floating-point values of NaN are treated as 0, values of +Infinity and -Infinity are clamped to the largest and smallest available float values.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceViewportSet(uint surface,
	                                         float[] viewport)
	{
		return SVGAssetsBridge.API.svgtSurfaceViewportSet(surface, viewport);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceViewportSet(uint surface,
                                                    float[] viewport);
#endif

    /*
        Get the current surface viewport transformation: clockwise rotation around a point, followed by a post-translation.
        The pivot point (i.e. the point around which the rotation is performed) is expressed in the drawing surface
        coordinates system, the rotation angle must be specified in degrees.

        The 'values' parameter must be an array of (at least) 5 float entries, it will be filled with:
        - values[0] = rotation pivot x
        - values[1] = rotation pivot y
        - values[2] = rotation angle, in degrees
        - values[3] = post-translation x
        - values[4] = post-translation y

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified surface handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'values' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceViewportTransformGet(uint surface,
	                                                  float[] values)
	{
		return SVGAssetsBridge.API.svgtSurfaceViewportTransformGet(surface, values);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceViewportTransformGet(uint surface,
                                                             float[] values);
#endif

    /*
        Set the current surface viewport transformation: clockwise rotation around a point, followed by a post-translation.
        The pivot point (i.e. the point around which the rotation is performed) is expressed in the drawing surface
        coordinates system, the rotation angle must be specified in degrees.

        The 'values' parameter must be an array of (at least) 5 float entries, it must contain:
        - values[0] = rotation pivot x
        - values[1] = rotation pivot y
        - values[2] = rotation angle, in degrees
        - values[3] = post-translation x
        - values[4] = post-translation y

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified surface handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'values' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully

        NB: floating-point values of NaN are treated as 0, values of +Infinity and -Infinity are clamped to the largest and smallest available float values.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtSurfaceViewportTransformSet(uint surface,
	                                                  float[] values)
	{
		return SVGAssetsBridge.API.svgtSurfaceViewportTransformSet(surface, values);
	}
#else
    [DllImport(libName)]
    public static extern int svgtSurfaceViewportTransformSet(uint surface,
                                                             float[] values);
#endif

    /*
        Create and load an SVG document, specifying the whole xml string.

        Return SVGT_INVALID_HANDLE in case of errors, else a valid document handle.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static uint svgtDocCreate(string xmlText)
	{
		uint svgDoc = SVGT_INVALID_HANDLE;
	#if UNITY_WP8
		if (xmlText == null)
			return SVGT_INVALID_HANDLE;
		// convert the string to C/ansi format
		byte[] utf8Buffer = new byte[xmlText.Length + 1];
		int count = System.Text.UTF8Encoding.UTF8.GetBytes(xmlText, 0, xmlText.Length, utf8Buffer, 0);
		// append the final '\0', in order to be fully compatible with C strings
		utf8Buffer[xmlText.Length] = 0;
		// get the temporary buffer pointer
		GCHandle handle = GCHandle.Alloc(utf8Buffer, GCHandleType.Pinned);
		try
		{
			IntPtr cStr = handle.AddrOfPinnedObject();
			if (cStr != System.IntPtr.Zero)
				svgDoc = SVGAssetsBridge.API.svgtDocCreate(cStr.ToInt64());
		}
		finally
		{
			if (handle.IsAllocated)
				handle.Free();
		}
	#else
		// convert the string to C/ansi format and get the pointer
		System.IntPtr cStr = System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(xmlText);

		if (cStr != System.IntPtr.Zero)
		{
			svgDoc = SVGAssetsBridge.API.svgtDocCreate(cStr.ToInt64());
			System.Runtime.InteropServices.Marshal.FreeHGlobal(cStr);
		}
	#endif
		return svgDoc;
	}
#else
	[DllImport(libName)]
	public static extern uint svgtDocCreate(string xmlText);
#endif

    /*
        Destroy a previously created SVG document.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocDestroy(uint svgDoc)
	{
		return SVGAssetsBridge.API.svgtDocDestroy(svgDoc);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocDestroy(uint svgDoc);
#endif

    /*
        SVG content itself optionally can provide information about the appropriate viewport region for
        the content via the 'width' and 'height' XML attributes on the outermost <svg> element.
        Use this function to get the suggested viewport width, in pixels.

        It returns -1 (i.e. an invalid width) in the following cases:
        - the library has not previously been initialized through the svgtInit() function
        - outermost element is not an <svg> element
        - outermost <svg> element doesn't have a 'width' attribute specified
        - outermost <svg> element has a 'width' attribute specified in relative coordinates units (i.e. em, ex, % percentage)
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static float svgtDocWidth(uint svgDoc)
	{
		return SVGAssetsBridge.API.svgtDocWidth(svgDoc);
	}
#else
    [DllImport(libName)]
    public static extern float svgtDocWidth(uint svgDoc);
#endif

    /*
        SVG content itself optionally can provide information about the appropriate viewport region for
        the content via the 'width' and 'height' XML attributes on the outermost <svg> element.
        Use this function to get the suggested viewport height, in pixels.

        It returns -1 (i.e. an invalid height) in the following cases:
        - the library has not previously been initialized through the svgtInit() function
        - outermost element is not an <svg> element
        - outermost <svg> element doesn't have a 'height' attribute specified
        - outermost <svg> element has a 'height' attribute specified in relative coordinates units (i.e. em, ex, % percentage)
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static float svgtDocHeight(uint svgDoc)
	{
		return SVGAssetsBridge.API.svgtDocHeight(svgDoc);
	}
#else
    [DllImport(libName)]
    public static extern float svgtDocHeight(uint svgDoc);
#endif

    /*
        Get the document (logical) viewport to map onto the destination (drawing surface) viewport.
        When an SVG document has been created through the svgtDocCreate function, the initial value
        of its viewport is equal to the 'viewBox' attribute present in the outermost <svg> element.
        If such element does not contain the viewBox attribute, SVGT_NO_ERROR is returned and viewport
        array will be filled with zeros.

        The 'viewport' parameter must be an array of (at least) 4 float entries, it will be filled with:
        - viewport[0] = top/left x
        - viewport[1] = top/left y
        - viewport[2] = width
        - viewport[3] = height

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified document handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'viewport' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocViewportGet(uint svgDoc,
	                                     float[] viewport)
	{
		return SVGAssetsBridge.API.svgtDocViewportGet(svgDoc, viewport);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocViewportGet(uint svgDoc,
                                                float[] viewport);
#endif

    /*
        Set the document (logical) viewport to map onto the destination (drawing surface) viewport.

        The 'viewport' parameter must be an array of (at least) 4 float entries, it must contain:
        - viewport[0] = top/left x
        - viewport[1] = top/left y
        - viewport[2] = width
        - viewport[3] = height

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified document handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'viewport' pointer is NULL or if it's not properly aligned
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified viewport width or height are less than or equal zero
        - SVGT_NO_ERROR if the operation was completed successfully

        NB: floating-point values of NaN are treated as 0, values of +Infinity and -Infinity are clamped to the largest and smallest available float values.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocViewportSet(uint svgDoc,
	                                     float[] viewport)
	{
		return SVGAssetsBridge.API.svgtDocViewportSet(svgDoc, viewport);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocViewportSet(uint svgDoc,
                                                float[] viewport);
#endif

    /*
        Get the document alignment.
        The alignment parameter indicates whether to force uniform scaling and, if so, the alignment method to use in case
        the aspect ratio of the document viewport doesn't match the aspect ratio of the surface viewport.

        The 'values' parameter must be an array of (at least) 2 unsigned integers entries, it will be filled with:
        - values[0] = alignment (see SVGTAspectRatioAlign)
        - values[1] = meetOrSlice (see SVGTAspectRatioMeetOrSlice)

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified document handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'values' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocViewportAlignmentGet(uint svgDoc,
	                                              uint[] values)
	{
		return SVGAssetsBridge.API.svgtDocViewportAlignmentGet(svgDoc, values);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocViewportAlignmentGet(uint svgDoc,
                                                         uint[] values);
#endif

    /*
        Set the document alignment.
        The alignment parameter indicates whether to force uniform scaling and, if so, the alignment method to use in case
        the aspect ratio of the document viewport doesn't match the aspect ratio of the surface viewport.

        The 'values' parameter must be an array of (at least) 2 unsigned integers entries, it must contain:
        - values[0] = alignment (see SVGTAspectRatioAlign)
        - values[1] = meetOrSlice (see SVGTAspectRatioMeetOrSlice)

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified document handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'values' pointer is NULL or if it's not properly aligned
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified alignment is not a valid SVGTAspectRatioAlign value
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified meetOrSlice is not a valid SVGTAspectRatioMeetOrSlice value
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocViewportAlignmentSet(uint svgDoc,
	                                              uint[] values)
	{
		return SVGAssetsBridge.API.svgtDocViewportAlignmentSet(svgDoc, values);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocViewportAlignmentSet(uint svgDoc,
                                                         uint[] values);
#endif

    /*
        Draw an SVG document, on the specified drawing surface.
        If the specified SVG document is SVGT_INVALID_HANDLE, the drawing surface is cleared (or not) according to the current
        settings (see svgtClearColor and svgtClearPerform), and nothing else is drawn.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtDocDraw(uint svgDoc,
	                              uint surface,
	                              uint renderingQuality)
	{
		return SVGAssetsBridge.API.svgtDocDraw(svgDoc, surface, renderingQuality);
	}
#else
    [DllImport(libName)]
    public static extern int svgtDocDraw(uint svgDoc,
                                         uint surface,
                                         uint renderingQuality);
#endif

    /*
        Set the clear color (i.e. the color used to clear the whole drawing surface).
        Each color component must be a number between 0 and 1. Values outside this range
        will be clamped.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtClearColor(float r,
	                                 float g,
	                                 float b,
	                                 float a)
	{
		return SVGAssetsBridge.API.svgtClearColor(r, g, b, a);
	}
#else
    [DllImport(libName)]
    public static extern int svgtClearColor(float r,
                                            float g,
                                            float b,
                                            float a);
#endif

    /*
        Specify if the whole drawing surface must be cleared by the svgtDocDraw function, before to draw the SVG document.

        It returns SVGT_NO_ERROR if the operation was completed successfully, else an error code.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtClearPerform(int doClear)
	{
		return SVGAssetsBridge.API.svgtClearPerform(doClear);
	}
#else
    [DllImport(libName)]
    public static extern int svgtClearPerform(int doClear);
#endif

    /*
        Map a point, expressed in the document viewport system, into the surface viewport.
        The transformation will be performed according to the current document viewport (see svgtDocViewportGet) and the
        current surface viewport (see svgtSurfaceViewportGet).

        The includeDstViewportTransformation parameter specifies if the surface viewport transformation (see svgtSurfaceViewportTransformGet)
        must be considered/included during the mapping operation.

        The 'dst' parameter must be an array of (at least) 2 float entries, it will be filled with:
        - dst[0] = transformed x
        - dst[1] = transformed y

        This function returns:
        - SVGT_BAD_HANDLE_ERROR if specified document (or surface) handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'dst' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully

        NB: floating-point values of NaN are treated as 0, values of +Infinity and -Infinity are clamped to the largest and smallest available float values.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPointMap(uint svgDoc,
	                               uint surface,
	                               float x,
	                               float y,
	                               int includeSurfaceViewportTransformation,
	                               float[] dst)
	{
		return SVGAssetsBridge.API.svgtPointMap(svgDoc, surface, x, y, includeSurfaceViewportTransformation, dst);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPointMap(uint svgDoc,
                                          uint surface,
                                          float x,
                                          float y,
                                          int includeSurfaceViewportTransformation,
                                          float[] dst);
#endif

    /*!
        Start a packing task: one or more SVG documents will be collected and packed into bins, for the generation of atlases.

        Every collected SVG document/element will be packed into rectangular bins, whose dimensions won't exceed the specified 'maxDimension', in pixels.
        If SVGT_TRUE, 'pow2Bins' will force bins to have power-of-two dimensions.
        Each rectangle will be separated from the others by the specified 'border', in pixels.
        The specified 'scale' factor will be applied to all collected SVG documents/elements, in order to realize resolution-independent atlases.

        This function returns:
        - SVGT_STILL_PACKING_ERROR if a current packing task is still open
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'maxDimension' is 0
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'pow2Bins' is SVGT_TRUE and the specified 'maxDimension' is not a power-of-two number
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'border' itself would exceed the specified 'maxDimension' (border must allow a packable region of at least one pixel)
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'scale' factor is less than or equal 0
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingBegin(uint maxDimension,
	                                   uint border,
	                                   int pow2Bins,
	                                   float scale)
	{
		return SVGAssetsBridge.API.svgtPackingBegin(maxDimension, border, pow2Bins, scale);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingBegin(uint maxDimension,
                                              uint border,
                                              int pow2Bins,
                                              float scale);
#endif

    /*!
        Add an SVG document to the current packing task.

        If SVGT_TRUE, 'explodeGroups' tells the packer to not pack the whole SVG document, but instead to pack each first-level element separately.

        The 'info' parameter will return some useful information, it must be an array of (at least) 2 entries and it will be filled with:
        - info[0] = number of collected bounding boxes
        - info[1] = the actual number of packed bounding boxes (boxes whose dimensions exceed the 'maxDimension' value specified to the svgtPackingBegin function, will be discarded)
        
        This function returns:
        - SVGT_NOT_PACKING_ERROR if there isn't a currently open packing task
        - SVGT_BAD_HANDLE_ERROR if specified document handle is not valid
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'info' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingAdd(uint svgDoc,
	                                 int explodeGroups,
	                                 uint[] info)
	{
		return SVGAssetsBridge.API.svgtPackingAdd(svgDoc, explodeGroups, info);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingAdd(uint svgDoc,
                                            int explodeGroups,
                                            uint[] info);
#endif

    /*!
        Close the current packing task and, if specified, perform the real packing algorithm.

        All collected SVG documents/elements (actually their bounding boxes) are packed into bins for later use (i.e. atlases generation).

        This function returns:
        - SVGT_NOT_PACKING_ERROR if there isn't a currently open packing task
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingEnd(int performPacking)
	{
		return SVGAssetsBridge.API.svgtPackingEnd(performPacking);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingEnd(int performPacking);
#endif

    /*!
        Return the number of generate bins from the last packing task.
        
        This function returns a negative number in case of errors (e.g. if the current packing task has not been previously closed by a call to svgtPackingEnd).
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingBinsCount()
	{
		return SVGAssetsBridge.API.svgtPackingBinsCount();
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingBinsCount();
#endif

    /*!
        Return information about the specified bin.

        The requested bin is selected by its index; the 'binInfo' parameter must be an array of (at least) 3 entries, it will be filled with:
        - binInfo[0] = bin width, in pixels
        - binInfo[1] = bin height, in pixels
        - binInfo[2] = number of packed rectangles inside the bin

        This function returns:
        - SVGT_STILL_PACKING_ERROR if a current packing task is still open
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'binIdx' is not valid (must be >= 0 and less than the value returned by svgtPackingBinsCount function)
        - SVGT_ILLEGAL_ARGUMENT_ERROR if 'binInfo' pointer is NULL or if it's not properly aligned
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingBinInfo(uint binIdx,
	                                     uint[] binInfo)
	{
		return SVGAssetsBridge.API.svgtPackingBinInfo(binIdx, binInfo);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingBinInfo(uint binIdx,
                                                uint[] binInfo);
#endif

    /*!
        Get access to packed rectangles, relative to a specified bin.

        The specified 'binIdx' must be >= 0 and less than the value returned by svgtPackingBinsCount function, else a NULL pointer will be returned.
        The returned pointer contains an array of packed rectangles, whose number is equal to the one gotten through the svgtPackingBinInfo function.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static System.IntPtr svgtPackingBinRects(uint binIdx)
	{
		return (System.IntPtr)SVGAssetsBridge.API.svgtPackingBinRects(binIdx);
	}
#else
    [DllImport(libName)]
    public static extern System.IntPtr svgtPackingBinRects(uint binIdx);
#endif

    /*!
        Draw a set of packed SVG documents/elements over the specified drawing surface.

        The drawing surface is cleared (or not) according to the current settings (see svgtClearColor and svgtClearPerform).

        This function returns:
        - SVGT_STILL_PACKING_ERROR if a current packing task is still open
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'binIdx' is not valid (must be >= 0 and less than the value returned by svgtPackingBinsCount function)
        - SVGT_ILLEGAL_ARGUMENT_ERROR if specified 'startRectIdx', along with 'rectsCount', identifies an invalid range of rectangles; defined:

            maxCount = binInfo[2] (see svgtPackingBinInfo)
            endRectIdx = 'startRectIdx' + 'rectsCount' - 1

        it must be ensured that 'startRectIdx' < maxCount and 'endRectIdx' < maxCount, else SVGT_ILLEGAL_ARGUMENT_ERROR is returned.

        - SVGT_BAD_HANDLE_ERROR if specified surface handle is not valid
        - SVGT_NO_ERROR if the operation was completed successfully
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static int svgtPackingDraw(uint binIdx,
	                                  uint startRectIdx,
	                                  uint rectsCount,
	                                  uint surface,
	                                  uint renderingQuality)
	{
		return SVGAssetsBridge.API.svgtPackingDraw(binIdx, startRectIdx, rectsCount, surface, renderingQuality);
	}
#else
    [DllImport(libName)]
    public static extern int svgtPackingDraw(uint binIdx,
                                             uint startRectIdx,
                                             uint rectsCount,
                                             uint surface,
                                             uint renderingQuality);
#endif

    /*
        Get renderer and version information.
    */
#if (UNITY_WP8 || UNITY_WP_8_1) && !UNITY_EDITOR
	public static System.IntPtr svgtGetString(uint name)
	{
		return (System.IntPtr)SVGAssetsBridge.API.svgtGetString(name);
	}
#else
    [DllImport(libName)]
    public static extern System.IntPtr svgtGetString(uint name);
#endif

    /*
        Get the description of the specified error code.
    */
    public static string svgtErrorDesc(int errorCode)
    {
        switch (errorCode)
        {
            case SVGT_NO_ERROR:
                return "";
            case SVGT_NOT_INITIALIZED_ERROR:
                return "AmanithSVG library has not been initialized (see svgtInit)";
            case SVGT_BAD_HANDLE_ERROR:
                return "Bad handle";
            case SVGT_ILLEGAL_ARGUMENT_ERROR:
                return "Illegal argument";
            case SVGT_OUT_OF_MEMORY_ERROR:
                return "Out of memory";
            case SVGT_PARSER_ERROR:
                return "Parser detected an invalid xml (element or attribute)";
            case SVGT_INVALID_SVG_ERROR:
                return "Outermost element is not an <svg>, or there is a circular dependency (generated by <use> elements)";
            case SVGT_STILL_PACKING_ERROR:
                return "A packing task is still open/running";
            case SVGT_NOT_PACKING_ERROR:
                return "There is not an open/running packing task";
            default:
                return "Unknown error";
        }
    }

    /*
        Log an error message.
    */
    public static void svgtErrorLog(string msgPrefix,
                                    int errorCode)
    {
        UnityEngine.Debug.Log(msgPrefix + svgtErrorDesc(errorCode));
    }
}

/*
    Simple color class.
*/
public class SVGColor
{
    // Constructor.
    public SVGColor()
    {
        _r = 1.0f;
        _g = 1.0f;
        _b = 1.0f;
        _a = 0.0f;
    }

    // Set constructor.
    public SVGColor(float r, float g, float b, float a)
    {
        // clamp each component in the [0; 1] range
        _r = (r < 0.0f) ? 0.0f : (r > 1.0f) ? 1.0f : r;
        _g = (g < 0.0f) ? 0.0f : (g > 1.0f) ? 1.0f : g;
        _b = (b < 0.0f) ? 0.0f : (b > 1.0f) ? 1.0f : b;
        _a = (a < 0.0f) ? 0.0f : (a > 1.0f) ? 1.0f : a;
    }

    // Red component (read only).
    public float Red
    {
        get
        {
            return _r;
        }
    }

    // Green component (read only).
    public float Green
    {
        get
        {
            return _g;
        }
    }

    // Blue component (read only).
    public float Blue
    {
        get
        {
            return _b;
        }
    }

    // Alpha component (read only).
    public float Alpha
    {
        get
        {
            return _a;
        }
    }

    // Red component.
    private float _r;
    // Green component.
    private float _g;
    // Blue component.
    private float _b;
    // Alpha component.
    private float _a;
}

public class SVGPoint
{
    // Constructor.
    public SVGPoint()
    {
        this._x = 0.0f;
        this._y = 0.0f;
    }

    // Set constructor.
    public SVGPoint(float x, float y)
    {
        this._x = x;
        this._y = y;
    }

    // Abscissa.
    public float X
    {
        get
        {
            return this._x;
        }
    }

    // Ordinate.
    public float Y
    {
        get
        {
            return this._y;
        }
    }

    private float _x;
    private float _y;
}

/*
    SVG viewport.

    A viewport represents a rectangular area, specified by its top/left corner, a width and an height.
    The positive x-axis points towards the right, the positive y-axis points down.
*/
public class SVGViewport
{
    // Constructor.
    public SVGViewport()
    {
        this._x = 0.0f;
        this._y = 0.0f;
        this._width = 0.0f;
        this._height = 0.0f;
        this._changed = true;
    }

    // Set constructor.
    public SVGViewport(float x, float y, float width, float height)
    {
        this._x = x;
        this._y = y;
        this._width = (width < 0.0f) ? 0.0f : width;
        this._height = (height < 0.0f) ? 0.0f : height;
        this._changed = true;
    }

    // Top/left corner, abscissa.
    public float X
    {
        get
        {
            return this._x;
        }
        set
        {
            this._x = value;
            this._changed = true;
        }
    }

    // Top/left corner, ordinate.
    public float Y
    {
        get
        {
            return this._y;
        }
        set
        {
            this._y = value;
            this._changed = true;
        }
    }

    // Viewport width.
    public float Width
    {
        get
        {
            return this._width;
        }
        set
        {
            this._width = (value < 0.0f) ? 0.0f : value;
            this._changed = true;
        }
    }

    // Viewport height.
    public float Height
    {
        get
        {
            return this._height;
        }
        set
        {
            this._height = (value < 0.0f) ? 0.0f : value;
            this._changed = true;
        }
    }

    internal bool Changed
    {
        get
        {
            return this._changed;
        }
        set
        {
            this._changed = value;
        }
    }

    // Top/left corner, x.
    private float _x;
    // Top/left corner, y.
    private float _y;
    // Viewport width.
    private float _width;
    // Viewport height.
    private float _height;
    // Keep track if some parameter has been chaged.
    private bool _changed;
}

/*
    A viewport transformation: clockwise rotation around a point, followed by a (post)translation.
    The pivot point (i.e. the point around which the rotation is performed) is expressed in the drawing surface
    coordinates system, the rotation angle must be specified in degrees.
*/
public class SVGViewportTransform
{
    // Constructor.
    public SVGViewportTransform()
    {
        this._pivot = new SVGPoint(0.0f, 0.0f);
        this._angle = 0.0f;
        this._translation = new SVGPoint(0.0f, 0.0f);
        this._changed = true;
    }

    // Set constructor.
    public SVGViewportTransform(SVGPoint pivot, float degAngle, SVGPoint translation)
    {
        this._pivot = new SVGPoint(pivot.X, pivot.Y);
        this._angle = degAngle;
        this._translation = new SVGPoint(translation.X, translation.Y);
        this._changed = true;
    }

    // The pivot point (i.e. the point around which the rotation is performed).
    public SVGPoint Pivot
    {
        get
        {
            return this._pivot;
        }
        set
        {
            this._pivot = new SVGPoint(value.X, value.Y);
            this._changed = true;
        }
    }

    // The rotation angle, expressed in degrees.
    public float Angle
    {
        get
        {
            return this._angle;
        }
        set
        {
            this._angle = value;
            this._changed = true;
        }
    }

    // The post-translation vector.
    public SVGPoint Translation
    {
        get
        {
            return this._translation;
        }
        set
        {
            this._translation = new SVGPoint(value.X, value.Y);
            this._changed = true;
        }
    }

    internal bool Changed
    {
        get
        {
            return this._changed;
        }
        set
        {
            this._changed = value;
        }
    }

    // The pivot point (i.e. the point around which the rotation is performed).
    private SVGPoint _pivot;
    // The rotation angle, expressed in degrees.
    private float _angle;
    // The post-translation vector.
    private SVGPoint _translation;
    // Keep track if some parameter has been chaged.
    private bool _changed;
}

public enum SVGAlign
{
    /*
        SVGTAspectRatioAlign

        Alignment indicates whether to force uniform scaling and, if so, the alignment method to use in case the aspect ratio of the source
        viewport doesn't match the aspect ratio of the destination (drawing surface) viewport.
    */

    /*
        Do not force uniform scaling.
        Scale the graphic content of the given element non-uniformly if necessary such that
        the element's bounding box exactly matches the viewport rectangle.
        NB: in this case, the <meetOrSlice> value is ignored.
    */
    None = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_NONE,

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    XMinYMin = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMINYMIN,

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    XMidYMin = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMIDYMIN,

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <min-y> of the source viewport with the smallest y value of the destination (drawing surface) viewport.
    */
    XMaxYMin = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMAXYMIN,

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    XMinYMid = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMINYMID,

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    XMidYMid = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMIDYMID,

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <mid-y> of the source viewport with the midpoint y value of the destination (drawing surface) viewport.
    */
    XMaxYMid = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMAXYMID,

    /*
        Force uniform scaling.
        Align the <min-x> of the source viewport with the smallest x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    XMinYMax = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMINYMAX,

    /*
        Force uniform scaling.
        Align the <mid-x> of the source viewport with the midpoint x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    XMidYMax = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMIDYMAX,

    /*
        Force uniform scaling.
        Align the <max-x> of the source viewport with the maximum x value of the destination (drawing surface) viewport.
        Align the <max-y> of the source viewport with the maximum y value of the destination (drawing surface) viewport.
    */
    XMaxYMax = AmanithSVG.SVGT_ASPECT_RATIO_ALIGN_XMAXYMAX
}

public enum SVGMeetOrSlice
{
    /*
        Scale the graphic such that:
        - aspect ratio is preserved
        - the entire viewBox is visible within the viewport
        - the viewBox is scaled up as much as possible, while still meeting the other criteria

        In this case, if the aspect ratio of the graphic does not match the viewport, some of the viewport will
        extend beyond the bounds of the viewBox (i.e., the area into which the viewBox will draw will be smaller
        than the viewport).
    */
    Meet = AmanithSVG.SVGT_ASPECT_RATIO_MEET,

    /*
        Scale the graphic such that:
        - aspect ratio is preserved
        - the entire viewport is covered by the viewBox
        - the viewBox is scaled down as much as possible, while still meeting the other criteria
        
        In this case, if the aspect ratio of the viewBox does not match the viewport, some of the viewBox will
        extend beyond the bounds of the viewport (i.e., the area into which the viewBox will draw is larger
        than the viewport).
    */
    Slice = AmanithSVG.SVGT_ASPECT_RATIO_SLICE
}

public enum SVGRenderingQuality
{
    /* Disables antialiasing */
    NonAntialiased = AmanithSVG.SVGT_RENDERING_QUALITY_NONANTIALIASED,
    /* Causes rendering to be done at the highest available speed */
    Faster = AmanithSVG.SVGT_RENDERING_QUALITY_FASTER,
    /* Causes rendering to be done with the highest available quality */
    Better = AmanithSVG.SVGT_RENDERING_QUALITY_BETTER
}

public class SVGAspectRatio
{
    // Constructor.
    public SVGAspectRatio()
    {
        this._alignment = SVGAlign.XMidYMid;
        this._meetOrSlice = SVGMeetOrSlice.Meet;
        this._changed = true;
    }

    // Set constructor.
    public SVGAspectRatio(SVGAlign alignment, SVGMeetOrSlice meetOrSlice)
    {
        this._alignment = alignment;
        this._meetOrSlice = meetOrSlice;
        this._changed = true;
    }

    // Alignment.
    public SVGAlign Alignment
    {
        get
        {
            return this._alignment;
        }
        set
        {
            this._alignment = value;
            this._changed = true;
        }
    }

    // Meet or slice.
    public SVGMeetOrSlice MeetOrSlice
    {
        get
        {
            return this._meetOrSlice;
        }
        set
        {
            this._meetOrSlice = value;
            this._changed = true;
        }
    }

    internal bool Changed
    {
        get
        {
            return this._changed;
        }
        set
        {
            this._changed = value;
        }
    }

    // Alignment.
    private SVGAlign _alignment;
    // Meet or slice.
    private SVGMeetOrSlice _meetOrSlice;
    // Keep track if some parameter has been chaged.
    private bool _changed;
}

/*
    SVG document.

    An SVG document can be created through SVGAssets.CreateDocument function, specifying the xml text.
    The document will be parsed immediately, and the internal drawing tree will be created.

    Once the document has been created, it can be drawn several times onto one (or more) drawing surface.
    In order to draw a document:

    (1) create a drawing surface using SVGAssets.CreateSurface
    (2) call surface Draw method, specifying the document to draw
*/
public class SVGDocument : IDisposable
{
    // Constructor.
    internal SVGDocument(uint handle)
    {
        int err;
        float[] viewport = new float[4];
        uint[] aspectRatio = new uint[2];

        // keep track of the AmanithSVG document handle
        this._handle = handle;
        this._disposed = false;

        // get document viewport
        if ((err = AmanithSVG.svgtDocViewportGet(this._handle, viewport)) == AmanithSVG.SVGT_NO_ERROR)
            this._viewport = new SVGViewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        else
        {
            this._viewport = null;
            // log an error message
            AmanithSVG.svgtErrorLog("Error getting document viewport: ", err);
        }

        // get viewport aspect ratio/alignment
        if ((err = AmanithSVG.svgtDocViewportAlignmentGet(this._handle, aspectRatio)) == AmanithSVG.SVGT_NO_ERROR)
            this._aspectRatio = new SVGAspectRatio((SVGAlign)aspectRatio[0], (SVGMeetOrSlice)aspectRatio[1]);
        else
        {
            this._aspectRatio = null;
            // log an error message
            AmanithSVG.svgtErrorLog("Error getting document aspect ratio/alignment: ", err);
        }
    }

    // Destructor.
    ~SVGDocument()
    {
        Dispose(false);
    }

    // Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // check to see if Dispose has already been called
        if (!this._disposed)
        {
            // if disposing equals true, dispose all managed and unmanaged resources
            if (disposing)
            {
                // dispose managed resources (nothing to do here)
            }
            // dispose unmanaged resources
            if (this._handle != AmanithSVG.SVGT_INVALID_HANDLE)
            {
                AmanithSVG.svgtDocDestroy(this._handle);
                this._handle = AmanithSVG.SVGT_INVALID_HANDLE;
            }
            // disposing has been done
            this._disposed = true;
        }
    }

    // If needed, update document viewport at AmanithSVG backend side; it returns true if the operation was completed successfully, else false.
    internal bool UpdateViewport()
    {
        int err;

        // set document viewport (AmanithSVG backend)
        if (this._viewport != null && this._viewport.Changed)
        {
            float[] viewport = new float[4] { this._viewport.X, this._viewport.Y, this._viewport.Width, this._viewport.Height };
            if ((err = AmanithSVG.svgtDocViewportSet(this._handle, viewport)) != AmanithSVG.SVGT_NO_ERROR)
            {
                // log an error message
                AmanithSVG.svgtErrorLog("Error setting surface viewport: ", err);
                return false;
            }
            this._viewport.Changed = false;
        }

        // set document viewport aspect ratio/alignment (AmanithSVG backend)
        if (this._aspectRatio != null && this._aspectRatio.Changed)
        {
            uint[] aspectRatio = new uint[2] { (uint)this._aspectRatio.Alignment, (uint)this._aspectRatio.MeetOrSlice };
            if ((err = AmanithSVG.svgtDocViewportAlignmentSet(this._handle, aspectRatio)) != AmanithSVG.SVGT_NO_ERROR)
            {
                // log an error message
                AmanithSVG.svgtErrorLog("Error setting document aspect ratio/alignment: ", err);
                return false;
            }
            this._aspectRatio.Changed = false;
        }

        return true;
    }

    /*
        Map a point, expressed in the document viewport system, into the surface viewport.
        The transformation will be performed according to the current document viewport and the
        current surface viewport.

        The includeDstViewportTransformation parameter specifies if the surface viewport transformation must be
        considered during the mapping operation.
    */
    public SVGPoint PointMap(SVGSurface surface, SVGPoint p, bool includeSurfaceViewportTransformation)
    {
        SVGPoint zero = new SVGPoint(0.0f, 0.0f);

        if (surface != null && p != null)
        {
            int err;
            float[] dst = new float[2];

            // update document viewport (AmanithSVG backend)
            if (!this.UpdateViewport())
                return zero;
            // update surface viewport (AmanithSVG backend)
            if (!surface.UpdateViewport())
                return zero;
            // map the specified point
            if ((err = AmanithSVG.svgtPointMap(this._handle, surface.Handle, p.X, p.Y, includeSurfaceViewportTransformation ? AmanithSVG.SVGT_TRUE : AmanithSVG.SVGT_FALSE, dst)) != AmanithSVG.SVGT_NO_ERROR)
            {
                // log an error message
                AmanithSVG.svgtErrorLog("Error mapping a point: ", err);
                return zero;
            }
            // return the result
            return new SVGPoint(dst[0], dst[1]);
        }
        else
            return zero;
    }


    // AmanithSVG document handle (read only).
    public uint Handle
    {
        get
        {
            return this._handle;
        }
    }

    /*
        SVG content itself optionally can provide information about the appropriate viewport region for
        the content via the 'width' and 'height' XML attributes on the outermost <svg> element.
        Use this property to get the suggested viewport width, in pixels.

        It returns -1 (i.e. an invalid width) in the following cases:
        - the library has not previously been initialized through the svgtInit function
        - outermost element is not an <svg> element
        - outermost <svg> element doesn't have a 'width' attribute specified
        - outermost <svg> element has a 'width' attribute specified in relative measure units (i.e. em, ex, % percentage)
    */
    public float Width
    {
        get
        {
            return AmanithSVG.svgtDocWidth(this._handle);
        }
    }

    /*
        SVG content itself optionally can provide information about the appropriate viewport region for
        the content via the 'width' and 'height' XML attributes on the outermost <svg> element.
        Use this property to get the suggested viewport height, in pixels.

        It returns -1 (i.e. an invalid height) in the following cases:
        - the library has not previously been initialized through the svgtInit function
        - outermost element is not an <svg> element
        - outermost <svg> element doesn't have a 'height' attribute specified
        - outermost <svg> element has a 'height' attribute specified in relative measure units (i.e. em, ex, % percentage)
    */
    public float Height
    {
        get
        {
            return AmanithSVG.svgtDocHeight(this._handle);
        }
    }

    /*
        The document (logical) viewport to map onto the destination (drawing surface) viewport.
        When an SVG document has been created through the SVGAssets.CreateDocument function, the initial
        value of its viewport is equal to the 'viewBox' attribute present in the outermost <svg> element.
    */
    public SVGViewport Viewport
    {
        get
        {
            return this._viewport;
        }
        set
        {
            if (value != null)
                this._viewport = value;
        }
    }

    /*
        Viewport aspect ratio.
        The alignment parameter indicates whether to force uniform scaling and, if so, the alignment method to use in case
        the aspect ratio of the document viewport doesn't match the aspect ratio of the surface viewport.
    */
    public SVGAspectRatio AspectRatio
    {
        get
        {
            return this._aspectRatio;
        }
        set
        {
            if (value != null)
                this._aspectRatio = value;
        }
    }

    // Document handle.
    private uint _handle;
    // Track whether Dispose has been called.
    private bool _disposed;
    // Viewport.
    private SVGViewport _viewport;
    // Viewport aspect ratio/alignment.
    private SVGAspectRatio _aspectRatio;
}

/*
    Drawing surface.

    A drawing surface is just a rectangular area made of pixels, where each pixel is represented internally by a 32bit unsigned integer.
    A pixel is made of four 8-bit components: red, green, blue, alpha.
 
    Coordinate system is the same of SVG specifications: top/left pixel has coordinate (0, 0), with the positive x-axis pointing towards
    the right and the positive y-axis pointing down.
*/
public class SVGSurface : IDisposable
{
    // Constructor.
    internal SVGSurface(uint handle)
    {
        int err;
        float[] viewport = new float[4];
        float[] viewportTransform = new float[5];

        // keep track of the AmanithSVG surface handle
        this._handle = handle;
        this._disposed = false;

        // get surface viewport
        if ((err = AmanithSVG.svgtSurfaceViewportGet(this._handle, viewport)) == AmanithSVG.SVGT_NO_ERROR)
            this._viewport = new SVGViewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        else
        {
            this._viewport = null;
            // log an error message
            AmanithSVG.svgtErrorLog("Error getting surface viewport: ", err);
        }

        // get viewport transformation
        if ((err = AmanithSVG.svgtSurfaceViewportTransformGet(this._handle, viewportTransform)) == AmanithSVG.SVGT_NO_ERROR)
            this._viewportTransform = new SVGViewportTransform(new SVGPoint(viewportTransform[0], viewportTransform[1]), viewportTransform[2], new SVGPoint(viewportTransform[3], viewportTransform[4]));
        else
        {
            this._viewportTransform = null;
            // log an error message
            AmanithSVG.svgtErrorLog("Error getting surface viewport transform: ", err);
        }
    }

    // Destructor.
    ~SVGSurface()
    {
        Dispose(false);
    }

    // Implement IDisposable.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        // check to see if Dispose has already been called
        if (!this._disposed)
        {
            // if disposing equals true, dispose all managed and unmanaged resources
            if (disposing)
            {
                // dispose managed resources (nothing to do here)
            }
            // dispose unmanaged resources
            if (this._handle != AmanithSVG.SVGT_INVALID_HANDLE)
            {
                AmanithSVG.svgtSurfaceDestroy(this._handle);
                this._handle = AmanithSVG.SVGT_INVALID_HANDLE;
            }
            // disposing has been done
            this._disposed = true;
        }
    }

    /*
        Resize the surface, specifying new dimensions in pixels; it returns true if the operation was completed successfully, else false.

        After resizing, the surface viewport will be reset to the whole surface, and the relative transformation will be reset to
        identity (pivot = [0; 0], angle = 0, post-translation = [0; 0]).
    */
    public bool Resize(uint newWidth, uint newHeight)
    {
        int err;

        if ((err = AmanithSVG.svgtSurfaceResize(this._handle, newWidth, newHeight)) != AmanithSVG.SVGT_NO_ERROR)
        {
            AmanithSVG.svgtErrorLog("Surface resize error: ", err);
            return false;
        }
        // svgtSurfaceResize will reset the surface viewport, so we must perform the same operation here
        this._viewport = new SVGViewport(0.0f, 0.0f, (float)this.Width, (float)this.Height);
        // svgtSurfaceResize will reset the surface viewport transformation to identity, so we must perform the same operation here
        this._viewportTransform = new SVGViewportTransform(new SVGPoint(0.0f, 0.0f), 0.0f, new SVGPoint(0.0f, 0.0f));
        return true;
    }

    // If needed, update surface viewport at AmanithSVG backend side; it returns true if the operation was completed successfully, else false.
    internal bool UpdateViewport()
    {
        int err;
        // set surface viewport (AmanithSVG backend)
        if (this._viewport != null && this._viewport.Changed)
        {
            float[] viewport = new float[4] { this._viewport.X, this._viewport.Y, this._viewport.Width, this._viewport.Height };
            if ((err = AmanithSVG.svgtSurfaceViewportSet(this._handle, viewport)) != AmanithSVG.SVGT_NO_ERROR)
            {
                // log an error message
                AmanithSVG.svgtErrorLog("Error setting surface viewport: ", err);
                return false;
            }
            this._viewport.Changed = false;
        }

        // set surface viewport transform (AmanithSVG backend)
        if (this._viewportTransform != null && this._viewportTransform.Changed)
        {
            float[] viewportTransform = new float[5] { this._viewportTransform.Pivot.X, this._viewportTransform.Pivot.Y, this._viewportTransform.Angle, this._viewportTransform.Translation.X, this._viewportTransform.Translation.Y };
            if ((err = AmanithSVG.svgtSurfaceViewportTransformSet(this._handle, viewportTransform)) != AmanithSVG.SVGT_NO_ERROR)
            {
                // log an error message
                AmanithSVG.svgtErrorLog("Error setting surface viewport transform: ", err);
                return false;
            }
            this._viewportTransform.Changed = false;
        }
        return true;
    }

    /*
        Draw an SVG document, on this drawing surface.

        First the drawing surface is cleared if a valid (i.e. not null) clear color is provided.
        Then the specified document, if valid, is drawn.

        It returns true if the operation was completed successfully, else false.
    */
    public bool Draw(SVGDocument document, SVGColor clearColor, SVGRenderingQuality renderingQuality)
    {
        int err;

        // set clear color
        if (!this.SetClearColor(clearColor))
            return false;

        if (document != null)
        {
            // update document viewport (AmanithSVG backend)
            if (!document.UpdateViewport())
                return false;
            // update surface viewport (AmanithSVG backend)
            if (!this.UpdateViewport())
                return false;

            // draw the document
            if ((err = AmanithSVG.svgtDocDraw(document.Handle, this.Handle, (uint)renderingQuality)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Surface draw error (drawing document): ", err);
                return false;
            }
        }
        return true;
    }

    public bool Draw(SVGPackedBin bin, SVGColor clearColor, SVGRenderingQuality renderingQuality)
    {
        int err;

        // set clear color
        if (!this.SetClearColor(clearColor))
            return false;

        if (bin != null && bin.Rectangles.Length > 0)
        {
            if ((err = AmanithSVG.svgtPackingDraw(bin.Index, 0, (uint)bin.Rectangles.Length, this.Handle, (uint)renderingQuality)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Surface draw error (drawing packed bin): ", err);
                return false;
            }
        }
        return true;
    }

    public bool Copy(Color32[] dstPixels32, bool dilateEdgesFix)
    {
        uint pixelsCount = this.Width * this.Height;

        if (dstPixels32 != null)
        {
            // check if there are enough entries in the destination array
            if (dstPixels32.Length >= pixelsCount)
            {
                // copy pixels from internal drawing surface to destination pixels array
                int err = AmanithSVG.svgtSurfaceCopy(this.Handle, dstPixels32, dilateEdgesFix ? AmanithSVG.SVGT_TRUE : AmanithSVG.SVGT_FALSE);
                // check for errors
                if (err != AmanithSVG.SVGT_NO_ERROR)
                {
                    AmanithSVG.svgtErrorLog("Surface copy (to texture) error: ", err);
                    return false;
                }
                return true;
            }
            else
            {
                AmanithSVG.svgtErrorLog("Surface copy error, not enough entries in the destination array: ", AmanithSVG.SVGT_ILLEGAL_ARGUMENT_ERROR);
                return false;
            }
        }
        else
        {
            AmanithSVG.svgtErrorLog("Surface copy error, specified destination array is null: ", AmanithSVG.SVGT_ILLEGAL_ARGUMENT_ERROR);
            return false;
        }
    }

    /*
        Copy drawing surface content into the specified texture.
        This function is useful for managed environments (e.g. C#, Unity, Java, Android), where the use of a direct pixels
        access is not advisable nor comfortable.
        It returns true if the operation was completed successfully, else false.
    */
    public bool Copy(Texture2D texture, bool dilateEdgesFix)
    {
        if (texture != null)
        {
            Color32[] dstPixels32 = texture.GetPixels32();

            if (this.Copy(dstPixels32, dilateEdgesFix))
            {
                texture.SetPixels32(dstPixels32);
                return true;
            }
            else
                return false;
        }
        else
        {
            AmanithSVG.svgtErrorLog("Surface copy error, specified texture is null: ", AmanithSVG.SVGT_ILLEGAL_ARGUMENT_ERROR);
            return false;
        }
    }

    // AmanithSVG surface handle (read only).
    public uint Handle
    {
        get
        {
            return this._handle;
        }
    }

    // Get current surface width, in pixels.
    public uint Width
    {
        get
        {
            return AmanithSVG.svgtSurfaceWidth(this._handle);
        }
    }

    // Get current surface height, in pixels.
    public uint Height
    {
        get
        {
            return AmanithSVG.svgtSurfaceHeight(this._handle);
        }
    }

    /*
        The surface viewport (i.e. a drawing surface rectangular area), where to map the source document viewport.
        The combined use of surface and document viewport, induces a transformation matrix, that will be used to draw
        the whole SVG document. The induced matrix grants that the document viewport is mapped onto the surface
        viewport (respecting the specified alignment): all SVG content will be drawn accordingly.
    */
    public SVGViewport Viewport
    {
        get
        {
            return this._viewport;
        }
        set
        {
            if (value != null)
                this._viewport = value;
        }
    }

    /*
        The current surface viewport transformation: clockwise rotation around a point, followed by a post-translation.
        The pivot point (i.e. the point around which the rotation is performed) is expressed in the drawing surface
        coordinates system, the rotation angle is specified in degrees.
    */
    public SVGViewportTransform ViewportTransform
    {
        get
        {
            return this._viewportTransform;
        }
        set
        {
            if (value != null)
                this._viewportTransform = value;
        }
    }

    // The maximum width/height dimension that can be specified to the SVGSurface.Resize and SVGAssets.CreateSurface functions.
    public static uint MaxDimension
    {
        get
        {
            return AmanithSVG.svgtSurfaceMaxDimension();
        }
    }

    private bool SetClearColor(SVGColor clearColor)
    {
        int err;

        if (clearColor != null)
        {
            // clear the whole surface, with the specified color
            if ((err = AmanithSVG.svgtClearColor(clearColor.Red, clearColor.Green, clearColor.Blue, clearColor.Alpha)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Surface draw error (setting clear color): ", err);
                return false;
            }
            if ((err = AmanithSVG.svgtClearPerform(AmanithSVG.SVGT_TRUE)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Surface draw error (enabling clear): ", err);
                return false;
            }
            return true;
        }
        else
        {
            // do not clear the surface
            if ((err = AmanithSVG.svgtClearPerform(AmanithSVG.SVGT_FALSE)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Surface draw error (disabling clear): ", err);
                return false;
            }
            return true;
        }
    }

    // Surface handle.
    private uint _handle = AmanithSVG.SVGT_INVALID_HANDLE;
    // Track whether Dispose has been called.
    private bool _disposed = false;
    // Viewport.
    private SVGViewport _viewport;
    // Viewport transformation.
    private SVGViewportTransform _viewportTransform;
}

public class SVGPackedRectangle
{
    // Constructor.
    public SVGPackedRectangle(uint docHandle, uint elemIdx, string name, int originalX, int originalY, int x, int y, int width, int height, int zOrder/*, float scale*/)
    {
        this._docHandle = docHandle;
        this._elemIdx = elemIdx;
        this._name = name;
        this._originalX = originalX;
        this._originalY = originalY;
        this._x = x;
        this._y = y;
        this._width = width;
        this._height = height;
        this._zOrder = zOrder;
        //this._scale = scale;
    }

    public uint DocHandle
    {
        get
        {
            return this._docHandle;
        }
    }

    public uint ElemIdx
    {
        get
        {
            return this._elemIdx;
        }
    }

    public string Name
    {
        get
        {
            return this._name;
        }
    }

    public int OriginalX
    {
        get
        {
            return this._originalX;
        }
    }
    
    public int OriginalY
    {
        get
        {
            return this._originalY;
        }
    }

    public int X
    {
        get
        {
            return this._x;
        }
    }

    public int Y
    {
        get
        {
            return this._y;
        }
    }

    public int Width
    {
        get
        {
            return this._width;
        }
    }

    public int Height
    {
        get
        {
            return this._height;
        }
    }

    public int ZOrder
    {
        get
        {
            return this._zOrder;
        }
    }

    /*
    public float Scale
    {
        get
        {
            return this._scale;
        }
    }
    */

    // SVG document handle
    private uint _docHandle;
    // SVG element (unique) identifier inside its document
    private uint _elemIdx;
    // Generated name
    private string _name;
    // Original top/left corner isnide the drawing surface
    private int _originalX;
    private int _originalY;
    // Top/left corner
    private int _x;
    private int _y;
    // Dimensions in pixels
    private int _width;
    private int _height;
    // Z-order
    private int _zOrder;
    //private float _scale;
}

public class SVGPackedBin
{
    // Constructor
    internal SVGPackedBin(uint index, uint width, uint height, uint rectsCount)
    {
        this._index = index;
        this._width = width;
        this._height = height;
        this._rects = new SVGPackedRectangle[rectsCount];
    }
    
    // Bin index
    public uint Index
    {
        get
        {
            return this._index;
        }
    }
    
    // Bin width, in pixels
    public uint Width
    {
        get
        {
            return this._width;
        }
    }
    
    // Bin height, in pixels
    public uint Height
    {
        get
        {
            return this._height;
        }
    }
    
    // Packed rectangles inside the bin
    internal SVGPackedRectangle[] Rectangles
    {
        get
        {
            return this._rects;
        }
    }   

    internal string GenElementName(AmanithSVG.SVGTPackedRect rect)
    {
        // build element name to be displayed in Unity editor
        string name = "";
        
        if (rect.elemName != System.IntPtr.Zero)
            name += System.Runtime.InteropServices.Marshal.PtrToStringAnsi(rect.elemName);
        else
            name += rect.elemIdx;

        return name;
    }

    // Bin index.
    private uint _index;
    // Width in pixels.
    private uint _width;
    // Height in pixels.
    private uint _height;
    // Packed rectangles inside the bin.
    SVGPackedRectangle[] _rects;
}

public class SVGPacker
{
    // Constructor.
    internal SVGPacker(float scale, uint maxTexturesDimension, uint border, bool pow2Textures)
    {
        this._scale = Math.Abs(scale);
        this._maxTexturesDimension = maxTexturesDimension;
        this._border = border;
        this._pow2Textures = pow2Textures;
        this.FixMaxDimension();
        this.FixBorder();
    }

    public float Scale
    {
        get
        {
            return this._scale;
        }
    }

    public uint MaxTexturesDimension
    {
        get
        {
            return this._maxTexturesDimension;
        }

        set
        {
            this._maxTexturesDimension = value;
            this.FixMaxDimension();
            this.FixBorder();
        }
    }
    
    public uint Border
    {
        get
        {
            return this._border;
        }

        set
        {
            this._border = value;
            this.FixBorder();
        }
    }

    public bool Pow2Textures
    {
        get
        {
            return this._pow2Textures;
        }

        set
        {
            this._pow2Textures = value;
            this.FixMaxDimension();
            this.FixBorder();
        }
    }

    public bool Begin()
    {
        int err = AmanithSVG.svgtPackingBegin(this._maxTexturesDimension, this._border, this._pow2Textures ? AmanithSVG.SVGT_TRUE : AmanithSVG.SVGT_FALSE, this._scale);
        // check for errors
        if (err != AmanithSVG.SVGT_NO_ERROR)
        {
            AmanithSVG.svgtErrorLog("SVGPacker.Begin error: ", err);
            return false;
        }
        return true;
    }

    public uint[] Add(SVGDocument svgDoc, bool explodeGroup)
    {
        uint[] info = new uint[2];
        // add an SVG document to the current packing task, and get back information about collected bounding boxes
        int err = AmanithSVG.svgtPackingAdd(svgDoc.Handle, explodeGroup ? AmanithSVG.SVGT_TRUE : AmanithSVG.SVGT_FALSE, info);
        
        // check for errors
        if (err != AmanithSVG.SVGT_NO_ERROR)
        {
            AmanithSVG.svgtErrorLog("SVGPacker.Begin error: ", err);
            return null;
        }
        // info[0] = number of collected bounding boxes
        // info[1] = the actual number of packed bounding boxes (boxes whose dimensions exceed the 'maxDimension' value specified to the svgtPackingBegin function, will be discarded)
        return info;
    }

    public SVGPackedBin[] End(bool performPacking)
    {
        int err, binsCount, rectSize;
        uint i, j;
        uint[] binInfo;
        SVGPackedBin[] bins;
        
        // close the current packing task
        if ((err = AmanithSVG.svgtPackingEnd(performPacking ? AmanithSVG.SVGT_TRUE : AmanithSVG.SVGT_FALSE)) != AmanithSVG.SVGT_NO_ERROR)
        {
            AmanithSVG.svgtErrorLog("SVGPacker.End error: ", err);
            return null;
        }
        // if requested, close the packing process without doing anything
        if (!performPacking)
            return null;
        // get number of generated bins
        binsCount = AmanithSVG.svgtPackingBinsCount();
        if (binsCount <= 0)
            return null;
        // allocate space for bins
        bins = new SVGPackedBin[binsCount];
        if (bins == null)
            return null;
        // allocate space to store information of a single bin
        binInfo = new uint[3];
        if (binInfo == null)
            return null;

	#if UNITY_WP_8_1 && !UNITY_EDITOR
		rectSize = Marshal.SizeOf<AmanithSVG.SVGTPackedRect>();
	#else
        rectSize = Marshal.SizeOf(typeof(AmanithSVG.SVGTPackedRect));
	#endif

        // fill bins information
        j = (uint)binsCount;
        for (i = 0; i < j; ++i)
        {
            uint k;
            System.IntPtr rectsPtr;
            SVGPackedBin bin;
            // get bin information
            if ((err = AmanithSVG.svgtPackingBinInfo(i, binInfo)) != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("SVGPacker.End error: ", err);
                return null;
            }
            // get packed rectangles
            rectsPtr = AmanithSVG.svgtPackingBinRects(i);
            if (rectsPtr == System.IntPtr.Zero)
                return null;
            // create new bin and store relative information (width, height, rectangles count)
            bin = new SVGPackedBin(i, binInfo[0], binInfo[1], binInfo[2]);
            // fill rectangles
            for (k = 0; k < binInfo[2]; ++k)
            {
                // rectangle generated by AmanithSVG packer
			#if UNITY_WP_8_1 && !UNITY_EDITOR
				AmanithSVG.SVGTPackedRect rect = (AmanithSVG.SVGTPackedRect)Marshal.PtrToStructure<AmanithSVG.SVGTPackedRect>(rectsPtr);
			#else
                AmanithSVG.SVGTPackedRect rect = (AmanithSVG.SVGTPackedRect)Marshal.PtrToStructure(rectsPtr, typeof(AmanithSVG.SVGTPackedRect));
			#endif
                // build element name to be displayed in Unity editor
                string name = bin.GenElementName(rect);
                // set the rectangle
                bin.Rectangles[k] = new SVGPackedRectangle(rect.docHandle, rect.elemIdx, name, rect.originalX, rect.originalY, rect.x, rect.y, rect.width, rect.height, rect.zOrder/*, rect.scale*/);
                // next packed rectangle
                rectsPtr = (System.IntPtr)(rectsPtr.ToInt64() + rectSize);
            }
            bins[i] = bin;
        }
        return bins;
    }

    // Given an unsigned value greater than 0, check if it's a power of two number.
    private bool IsPow2(uint value)
    {
        return (((value & (value - 1)) == 0) ? true : false);
    }

    // Return the smallest power of two greater than (or equal to) the specified value.
    private uint Pow2Get(uint value)
    {
        uint v = 1;

        while (v < value)
            v <<= 1;
        return v;
    }

    private void FixMaxDimension()
    {
        if (this._maxTexturesDimension == 0)
            this._maxTexturesDimension = 1;
        else
        {
            // check power-of-two option
            if (this._pow2Textures && (!this.IsPow2(this._maxTexturesDimension)))
                // set maxTexturesDimension to the smallest power of two value greater (or equal) to it
                this._maxTexturesDimension = this.Pow2Get(this._maxTexturesDimension);
        }
    }

    private void FixBorder()
    {
        // border must allow a packable region of at least one pixel
        uint maxAllowedBorder = ((this._maxTexturesDimension & 1) != 0) ? (this._maxTexturesDimension / 2) : ((this._maxTexturesDimension - 1) / 2);
        if (this._border > maxAllowedBorder)
            this._border = maxAllowedBorder;
    }

    private uint _baseWidth;
    private uint _baseHeight;
    private float _scale;
    private SVGScaleType _scaleType;
    private uint _maxTexturesDimension;
    private uint _border;
    private bool _pow2Textures;
}

static public class SVGAssets
{
    // Constructor.
    static SVGAssets()
    {
		SVGAssets.m_Initialized = false;
    }

	public static uint ScreenResolutionWidth
	{
		get
		{
			if (Application.isPlaying)
				return (uint)Screen.width;
			Vector2 view = SVGUtils.GetGameView();
			return (uint)view.x;
		}
	}
	
	public static uint ScreenResolutionHeight
	{
		get
		{
			if (Application.isPlaying)
				return (uint)Screen.height;
			Vector2 view = SVGUtils.GetGameView();
			return (uint)view.y;
		}
	}

	public static float ScreenDpi
    {
		get
		{
        	float dpi = Screen.dpi;
        	return (dpi <= 0.0f ? 96.0f : dpi);
		}
    }

	public static DeviceOrientation DeviceOrientation
	{
		get
		{
		#if UNITY_EDITOR
			return ((SVGAssets.ScreenResolutionHeight > SVGAssets.ScreenResolutionWidth) ? DeviceOrientation.Portrait : DeviceOrientation.LandscapeLeft);
		#else
			return Input.deviceOrientation;
		#endif
		}
	}

    // Create a drawing surface, specifying its dimensions in pixels.
    public static SVGSurface CreateSurface(uint width, uint height)
    {
        uint handle;

        // initialize the library, if required
		if (!SVGAssets.Init())
            return null;
        // create the surface
        if ((handle = AmanithSVG.svgtSurfaceCreate(width, height)) != AmanithSVG.SVGT_INVALID_HANDLE)
            return new SVGSurface(handle);
        AmanithSVG.svgtErrorLog("CreateSurface error (allocating surface): ", AmanithSVG.SVGT_OUT_OF_MEMORY_ERROR);
        return null;
    }

    // Create and load an SVG document, specifying the whole xml string.
    public static SVGDocument CreateDocument(string xmlText)
    {
        uint handle;

        // initialize the library, if required
		if (!SVGAssets.Init())
            return null;
        // create the document
        if ((handle = AmanithSVG.svgtDocCreate(xmlText)) != AmanithSVG.SVGT_INVALID_HANDLE)
            return new SVGDocument(handle);

        AmanithSVG.svgtErrorLog("CreateDocument error (parsing document): ", AmanithSVG.SVGT_OUT_OF_MEMORY_ERROR);
        return null;
    }

    public static SVGPacker CreatePacker(float scale, uint maxTexturesDimension, uint border, bool pow2Textures)
    {
        // initialize the library, if required
		if (!SVGAssets.Init())
            return null;
        
        return new SVGPacker(scale, maxTexturesDimension, border, pow2Textures);
    }

    // Get library version.
    public static string GetVersion()
    {
        return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(AmanithSVG.svgtGetString(AmanithSVG.SVGT_VERSION));
    }

    // Get library vendor.
    public static string GetVendor()
    {
        return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(AmanithSVG.svgtGetString(AmanithSVG.SVGT_VENDOR));
    }
    
    private static bool Init()
    {
		if (!SVGAssets.m_Initialized)
        {
			int err = AmanithSVG.svgtInit(SVGAssets.ScreenResolutionWidth, SVGAssets.ScreenResolutionHeight, SVGAssets.ScreenDpi);

            if (err != AmanithSVG.SVGT_NO_ERROR)
            {
                AmanithSVG.svgtErrorLog("Error initializing AmanithSVG the library: ", err);
                return false;
            }
			SVGAssets.m_Initialized = true;
        }
        return true;
    }

    // Keep track if AmanithSVG library has been initialized.
    private static bool m_Initialized;
}
