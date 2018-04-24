uniform sampler2D texture;
uniform float blurRadius;

void main()
{
    // lookup the pixel in the texture
    vec2 offx = vec2(0.008*blurRadius, 0.0);
    vec2 offy = vec2(0.0, 0.008*blurRadius);

    vec4 pixel = texture2D(texture, gl_TexCoord[0].xy)               * 0.25 +
                 texture2D(texture, gl_TexCoord[0].xy+vec2(1,0))     * 0.125 +
                 texture2D(texture, gl_TexCoord[0].xy + offx)        * 0.125 +
                 texture2D(texture, gl_TexCoord[0].xy - offy)        * 0.125 +
                 texture2D(texture, gl_TexCoord[0].xy + offy)        * 0.125 +
                 texture2D(texture, gl_TexCoord[0].xy - offx - offy) * 0.0625 +
                 texture2D(texture, gl_TexCoord[0].xy - offx + offy) * 0.0625 +
                 texture2D(texture, gl_TexCoord[0].xy + offx - offy) * 0.0625 +
                 texture2D(texture, gl_TexCoord[0].xy + offx + offy) * 0.0625;

    gl_FragColor =  gl_Color *(pixel);
	
}