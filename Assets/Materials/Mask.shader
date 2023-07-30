Shader "Custom/Mask"
{

  SubShader
  {
	 Tags {"Queue" = "Transparent+1" "RenderType" = "Transparent" "RenderPipeline" = "UniversalPipeline"}	 

  Pass
     {
		 Blend Zero One 
     }
  }

}
